using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 1. Middleware de Gestión de Errores
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new { error = "Internal server error." });
    }
});

// 2. Middleware de Autenticación
app.Use(async (context, next) =>
{
    // Permitir acceso a Swagger sin token
    if (context.Request.Path.StartsWithSegments("/swagger"))
    {
        await next();
        return;
    }

    if (!context.Request.Headers.TryGetValue("Authorization", out var token) || token != "Bearer mi-token-valido")
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsJsonAsync(new { error = "Unauthorized" });
        return;
    }

    await next();
});

// 3. Middleware de Registro (Logging)
app.Use(async (context, next) =>
{
    Console.WriteLine($"[LOG] Recibida solicitud: {context.Request.Method} {context.Request.Path}");
    
    await next();
    
    Console.WriteLine($"[LOG] Respuesta enviada con código: {context.Response.StatusCode}");
});

// In-memory list to store users
var users = new List<User>
{
    new User { Id = 1, Name = "Alice Smith", Email = "alice@example.com", Department = "HR" },
    new User { Id = 2, Name = "Bob Jones", Email = "bob@example.com", Department = "IT" }
};

// GET: Retrieve a list of all users
app.MapGet("/users", (int skip = 0, int take = 50) =>
{
    try
    {
        // Optimization: Added pagination to avoid performance issues with large datasets
        var paginatedUsers = users.Skip(skip).Take(take).ToList();
        return Results.Ok(paginatedUsers);
    }
    catch (Exception ex)
    {
        return Results.Problem("An error occurred while retrieving users: " + ex.Message);
    }
})
.WithName("GetAllUsers");

// GET: Retrieve a specific user by ID
app.MapGet("/users/{id}", (int id) =>
{
    try
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        return user is not null ? Results.Ok(user) : Results.NotFound(new { Message = "User not found" });
    }
    catch (Exception ex)
    {
        return Results.Problem("An error occurred while retrieving the user: " + ex.Message);
    }
})
.WithName("GetUserById");

// POST: Add a new user
app.MapPost("/users", (User newUser) =>
{
    try
    {
        // Validation: Ensure required fields are not empty and email is valid
        if (string.IsNullOrWhiteSpace(newUser.Name) || 
            string.IsNullOrWhiteSpace(newUser.Email) || 
            !newUser.Email.Contains("@"))
        {
            return Results.BadRequest(new { Message = "Invalid user data. Name is required and a valid Email must be provided." });
        }

        newUser.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
        users.Add(newUser);
        return Results.Created($"/users/{newUser.Id}", newUser);
    }
    catch (Exception ex)
    {
        return Results.Problem("An error occurred while creating the user: " + ex.Message);
    }
})
.WithName("CreateUser");

// PUT: Update an existing user's details
app.MapPut("/users/{id}", (int id, User updatedUser) =>
{
    try
    {
        // Validation: Ensure required fields are not empty and email is valid
        if (string.IsNullOrWhiteSpace(updatedUser.Name) || 
            string.IsNullOrWhiteSpace(updatedUser.Email) || 
            !updatedUser.Email.Contains("@"))
        {
            return Results.BadRequest(new { Message = "Invalid user data. Name is required and a valid Email must be provided." });
        }

        var user = users.FirstOrDefault(u => u.Id == id);
        if (user is null)
        {
            return Results.NotFound(new { Message = "User not found" });
        }

        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        user.Department = updatedUser.Department;

        return Results.Ok(user);
    }
    catch (Exception ex)
    {
        return Results.Problem("An error occurred while updating the user: " + ex.Message);
    }
})
.WithName("UpdateUser");

// DELETE: Remove a user by ID
app.MapDelete("/users/{id}", (int id) =>
{
    try
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user is null)
        {
            return Results.NotFound(new { Message = "User not found" });
        }

        users.Remove(user);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.Problem("An error occurred while deleting the user: " + ex.Message);
    }
})
.WithName("DeleteUser");

app.Run();

// User model
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
}
