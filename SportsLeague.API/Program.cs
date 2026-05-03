using Microsoft.EntityFrameworkCore;
using SportsLeague.DataAccess.Context;
using SportsLeague.DataAccess.Repositories;
using SportsLeague.Domain.Helpers;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;
using SportsLeague.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// ── Entity Framework Core ──
builder.Services.AddDbContext<LeagueDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ── Repositories ──
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IRefereeRepository, RefereeRepository>();           // NUEVO
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();     // NUEVO
builder.Services.AddScoped<ITournamentTeamRepository, TournamentTeamRepository>(); // NUEVO
builder.Services.AddScoped<ISponsorRepository, SponsorRepository>();        // NUEVO
builder.Services.AddScoped<IMatchRepository, MatchRepository>(); // NUEVO
builder.Services.AddScoped<IMatchResultRepository, MatchResultRepository>(); // NUEVO
builder.Services.AddScoped<IGoalRepository, GoalRepository>(); // NUEVO
builder.Services.AddScoped<ICardRepository, CardRepository>(); // NUEVO


// ── Services ──
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IRefereeService, RefereeService>();           // NUEVO
builder.Services.AddScoped<ITournamentService, TournamentService>();     // NUEVO
builder.Services.AddScoped<ISponsorService, SponsorService>();    // NUEVO
builder.Services.AddScoped<IMatchService, MatchService>(); // NUEVO
builder.Services.AddScoped<IMatchEventService, MatchEventService>(); // NUEVO
builder.Services.AddScoped<MatchValidationHelper>(); // NUEVO


// ── AutoMapper ──
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// ── Controllers ──
builder.Services.AddControllers();

// ── Swagger ──
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ── Middleware Pipeline ──
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
