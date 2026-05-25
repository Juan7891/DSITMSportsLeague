using SportsLeague.DataAccess.Context;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace SportsLeague.DataAccess.Seeders;

public static class DataSeeder
{
    public static async Task SeedAsync(LeagueDbContext context)
    {
        // Solo ejecutar si no hay equipos (BD vacía)
        if (await context.Teams.AnyAsync()) return;

        // ═══ 1. EQUIPOS (Liga BetPlay 2026) ═══
        var teams = new List<Team>
        {
            new() { Name="Atlético Nacional", City="Medellín", Stadium="Atanasio Girardot" },
            new() { Name="Independiente Medellín", City="Medellín", Stadium="Atanasio Girardot" },
            new() { Name="América de Cali", City="Cali", Stadium="Pascual Guerrero" },
            new() { Name="Deportivo Cali", City="Cali", Stadium="Deportivo Cali" },
            new() { Name="Junior FC", City="Barranquilla", Stadium="Metropolitano" },
            new() { Name="Millonarios FC", City="Bogotá", Stadium="El Campín" },
            new() { Name="Independiente Santa Fe", City="Bogotá", Stadium="El Campín" },
            new() { Name="Deportes Tolima", City="Ibagué", Stadium="Manuel Murillo Toro" },
            new() { Name="Atlético Bucaramanga", City="Bucaramanga", Stadium="Alfonso López" },
            new() { Name="Once Caldas", City="Manizales", Stadium="Palogrande" },
            new() { Name="Deportivo Pasto", City="Pasto", Stadium="Departamental Libertad" },
            new() { Name="Deportivo Pereira", City="Pereira", Stadium="Hernán Ramírez Villegas" },
            new() { Name="Águilas Doradas", City="Rionegro", Stadium="Alberto Grisales" },
            new() { Name="Boyacá Chicó FC", City="Tunja", Stadium="La Independencia" },
            new() { Name="Jaguares de Córdoba", City="Montería", Stadium="Jaraguay" },
            new() { Name="Alianza Valledupar FC", City="Valledupar", Stadium="Armando Maestre" },
            new() { Name="Fortaleza FC", City="Bogotá", Stadium="Metropolitano de Techo" },
            new() { Name="Llaneros FC", City="Villavicencio", Stadium="Bello Horizonte" },
            new() { Name="Cúcuta Deportivo", City="Cúcuta", Stadium="General Santander" },
            new() { Name="Internacional de Bogotá", City="Bogotá", Stadium="Metropolitano de Techo" },
        };

        context.Teams.AddRange(teams);
        await context.SaveChangesAsync();

        // ═══ 2. JUGADORES (4 por equipo = 80 total) ═══
        var playersData = new (string First, string Last, PlayerPosition Pos, int Number)[][]
        {
            // 1. Atlético Nacional
            new[] {
                ("David", "Ospina", PlayerPosition.Goalkeeper, 1),
                ("Kevin", "Mier", PlayerPosition.Goalkeeper, 12),       // GK suplente
                ("William", "Tesillo", PlayerPosition.Defender, 3),
                ("Emanuel", "Olivera", PlayerPosition.Defender, 4),
                ("Yerson", "Mosquera", PlayerPosition.Defender, 13),
                ("Álvaro", "Angulo", PlayerPosition.Defender, 6),
                ("Dorlan", "Pabón", PlayerPosition.Midfielder, 10),
                ("Edwin", "Cardona", PlayerPosition.Midfielder, 8),
                ("Sebastián", "Gómez", PlayerPosition.Midfielder, 5),
                ("Jarlan", "Barrera", PlayerPosition.Midfielder, 14),
                ("Alfredo", "Morelos", PlayerPosition.Forward, 9),
                ("Jefferson", "Duque", PlayerPosition.Forward, 7),
                ("Daniel", "Mantilla", PlayerPosition.Forward, 11),
                ("Tomás", "Ángel", PlayerPosition.Forward, 17),         // Suplente extra
            },

            // 2. Independiente Medellín
            new[] {
                ("Salvador", "Ichazo", PlayerPosition.Goalkeeper, 1),
                ("Harlen", "Castillo", PlayerPosition.Goalkeeper, 22),
                ("Andrés", "Cadavid", PlayerPosition.Defender, 4),
                ("Víctor", "Moreno", PlayerPosition.Defender, 3),
                ("Juan Pablo", "Gallego", PlayerPosition.Defender, 13),
                ("Germán", "Gutiérrez", PlayerPosition.Defender, 6),
                ("Adrián", "Arregui", PlayerPosition.Midfielder, 5),
                ("Jean", "Pineda", PlayerPosition.Midfielder, 8),
                ("Juan Carlos", "Díaz", PlayerPosition.Midfielder, 10),
                ("Andrés", "Ricaurte", PlayerPosition.Midfielder, 14),
                ("Luciano", "Pons", PlayerPosition.Forward, 9),
                ("Diber", "Cambindo", PlayerPosition.Forward, 7),
                ("León", "Flórez", PlayerPosition.Forward, 11),
                ("Hugo", "Restrepo", PlayerPosition.Forward, 17),
            },

            // 3. América de Cali
            new[] {
                ("Joel", "Graterol", PlayerPosition.Goalkeeper, 1),
                ("Diego", "Novoa", PlayerPosition.Goalkeeper, 12),
                ("Jorge", "Segura", PlayerPosition.Defender, 3),
                ("John", "García", PlayerPosition.Defender, 4),
                ("Pablo", "Ortiz", PlayerPosition.Defender, 13),
                ("Eber", "Moreno", PlayerPosition.Defender, 6),
                ("Rodrigo", "Ureña", PlayerPosition.Midfielder, 8),
                ("Luis", "Sánchez", PlayerPosition.Midfielder, 5),
                ("Carlos", "Sierra", PlayerPosition.Midfielder, 10),
                ("Yesus", "Cabrera", PlayerPosition.Midfielder, 14),
                ("Adrián", "Ramos", PlayerPosition.Forward, 9),
                ("Cristian", "Martínez", PlayerPosition.Forward, 7),
                ("Giovanny", "Barros", PlayerPosition.Forward, 11),
                ("Miguel", "Borja", PlayerPosition.Forward, 17),
            },

            // 4. Deportivo Cali
            new[] {
                ("Pedro", "Gallese", PlayerPosition.Goalkeeper, 1),
                ("Humberto", "Acevedo", PlayerPosition.Goalkeeper, 12),
                ("Fernando", "Álvarez", PlayerPosition.Defender, 4),
                ("Jorge", "Marsiglia", PlayerPosition.Defender, 3),
                ("Hernán", "Menosse", PlayerPosition.Defender, 13),
                ("Juan", "Camilo", PlayerPosition.Defender, 6),
                ("Kevin", "Velasco", PlayerPosition.Midfielder, 10),
                ("Andrés", "Colorado", PlayerPosition.Midfielder, 8),
                ("Gastón", "Rodríguez", PlayerPosition.Midfielder, 5),
                ("Jhojan", "Valencia", PlayerPosition.Midfielder, 14),
                ("Juan", "Dinenno", PlayerPosition.Forward, 9),
                ("Ángelo", "Rodríguez", PlayerPosition.Forward, 7),
                ("Harold", "Preciado", PlayerPosition.Forward, 11),
                ("Marco", "Pérez", PlayerPosition.Forward, 17),
            },

            // 5. Junior FC
            new[] {
                ("Mauro", "Silveira", PlayerPosition.Goalkeeper, 1),
                ("Sebastián", "Viera", PlayerPosition.Goalkeeper, 12),
                ("Edwin", "Herrera", PlayerPosition.Defender, 4),
                ("Willer", "Ditta", PlayerPosition.Defender, 3),
                ("Dany", "Rosero", PlayerPosition.Defender, 13),
                ("Gabriel", "Fuentes", PlayerPosition.Defender, 6),
                ("Fabián", "Ángel", PlayerPosition.Midfielder, 8),
                ("Didier", "Moreno", PlayerPosition.Midfielder, 5),
                ("Edwuin", "Cetré", PlayerPosition.Midfielder, 10),
                ("James", "Sánchez", PlayerPosition.Midfielder, 14),
                ("Carlos", "Bacca", PlayerPosition.Forward, 7),
                ("Miguel", "Ángel Borja", PlayerPosition.Forward, 9),
                ("Fernando", "Uribe", PlayerPosition.Forward, 11),
                ("Carmelo", "Valencia", PlayerPosition.Forward, 17),
            },

            // 6. Millonarios FC
            new[] {
                ("Guillermo", "De Amores", PlayerPosition.Goalkeeper, 1),
                ("Álvaro", "Montero", PlayerPosition.Goalkeeper, 12),
                ("Omar", "Bertel", PlayerPosition.Defender, 4),
                ("Andrés", "Llinás", PlayerPosition.Defender, 3),
                ("Juan Pablo", "Vargas", PlayerPosition.Defender, 13),
                ("Émerson", "Rivaldo", PlayerPosition.Defender, 6),
                ("Daniel", "Cataño", PlayerPosition.Midfielder, 10),
                ("Larry", "Vásquez", PlayerPosition.Midfielder, 8),
                ("Juan Carlos", "Pereira", PlayerPosition.Midfielder, 5),
                ("David", "Silva", PlayerPosition.Midfielder, 14),
                ("Leonardo", "Castro", PlayerPosition.Forward, 9),
                ("Diego", "Herazo", PlayerPosition.Forward, 7),
                ("Jader", "Valencia", PlayerPosition.Forward, 11),
                ("Luis Carlos", "Ruiz", PlayerPosition.Forward, 17),
            },

            // 7. Independiente Santa Fe
            new[] {
                ("Leandro", "Castellanos", PlayerPosition.Goalkeeper, 1),
                ("José", "Silva", PlayerPosition.Goalkeeper, 22),
                ("Elvis", "Mosquera", PlayerPosition.Defender, 3),
                ("Fáider", "Burbano", PlayerPosition.Defender, 4),
                ("Carlos", "Arboleda", PlayerPosition.Defender, 13),
                ("Neyder", "Moreno", PlayerPosition.Defender, 6),
                ("Daniel", "Giraldo", PlayerPosition.Midfielder, 5),
                ("Jéfferson", "Martínez", PlayerPosition.Midfielder, 8),
                ("Kelvin", "Osorio", PlayerPosition.Midfielder, 10),
                ("Jhon", "Velásquez", PlayerPosition.Midfielder, 14),
                ("Hugo", "Rodallega", PlayerPosition.Forward, 9),
                ("Wilson", "Morelo", PlayerPosition.Forward, 7),
                ("Joao", "Rojas", PlayerPosition.Forward, 11),
                ("Jersson", "González", PlayerPosition.Forward, 17),
            },

            // 8. Deportes Tolima
            new[] {
                ("William", "Cuesta", PlayerPosition.Goalkeeper, 1),
                ("Eder", "Chaux", PlayerPosition.Goalkeeper, 12),
                ("Jersson", "González", PlayerPosition.Defender, 3),
                ("Julián", "Quiñones", PlayerPosition.Defender, 4),
                ("Juan", "Caicedo", PlayerPosition.Defender, 13),
                ("Sergio", "Mosquera", PlayerPosition.Defender, 6),
                ("Junior", "Hernández", PlayerPosition.Midfielder, 10),
                ("Rodrigo", "Ureña", PlayerPosition.Midfielder, 8),
                ("Anderson", "Plata", PlayerPosition.Midfielder, 5),
                ("Brayan", "Rovira", PlayerPosition.Midfielder, 14),
                ("Tatay", "Torres", PlayerPosition.Forward, 9),
                ("Michael", "Rangel", PlayerPosition.Forward, 7),
                ("Juan Fernando", "Caicedo", PlayerPosition.Forward, 11),
                ("Gustavo", "Ramírez", PlayerPosition.Forward, 17),
            },

            // 9. Atlético Bucaramanga
            new[] {
                ("Juan Camilo", "Chaverra", PlayerPosition.Goalkeeper, 1),
                ("Ricardo", "Jerez", PlayerPosition.Goalkeeper, 22),
                ("José", "Ortiz", PlayerPosition.Defender, 4),
                ("Kevin", "Pérez", PlayerPosition.Defender, 3),
                ("Óscar", "Vanegas", PlayerPosition.Defender, 13),
                ("Brayan", "García", PlayerPosition.Defender, 6),
                ("Sherman", "Cárdenas", PlayerPosition.Midfielder, 10),
                ("Rafael", "Robayo", PlayerPosition.Midfielder, 8),
                ("Johan", "Caballero", PlayerPosition.Midfielder, 5),
                ("Jaime", "Alvarado", PlayerPosition.Midfielder, 14),
                ("Sebastián", "Pons", PlayerPosition.Forward, 9),
                ("Dayro", "Moreno", PlayerPosition.Forward, 7),
                ("Hugo", "Rodallega", PlayerPosition.Forward, 11),
                ("Fabián", "Sambueza", PlayerPosition.Forward, 17),
            },

            // 10. Once Caldas
            new[] {
                ("Gerardo", "Ortiz", PlayerPosition.Goalkeeper, 1),
                ("Norberto", "Araujo", PlayerPosition.Goalkeeper, 12),
                ("Edisson", "Palomino", PlayerPosition.Defender, 3),
                ("David", "Lemos", PlayerPosition.Defender, 4),
                ("Kevin", "Londoño", PlayerPosition.Defender, 13),
                ("Juan", "David Rodríguez", PlayerPosition.Defender, 6),
                ("Sebastián", "Gómez", PlayerPosition.Midfielder, 5),
                ("Diego", "Valdés", PlayerPosition.Midfielder, 8),
                ("Juan Pablo", "Nieto", PlayerPosition.Midfielder, 10),
                ("Marcelino", "Carreazo", PlayerPosition.Midfielder, 14),
                ("Dayro", "Moreno", PlayerPosition.Forward, 9),
                ("Jerson", "Malagón", PlayerPosition.Forward, 7),
                ("Jhon", "Córdoba", PlayerPosition.Forward, 11),
                ("Brayan", "Fernández", PlayerPosition.Forward, 17),
            },

            // 11. Deportivo Pasto
            new[] {
                ("Diego", "Martínez", PlayerPosition.Goalkeeper, 1),
                ("Juan", "Mosquera", PlayerPosition.Goalkeeper, 12),
                ("Camilo", "Ayala", PlayerPosition.Defender, 4),
                ("Geisson", "Perea", PlayerPosition.Defender, 3),
                ("Félix", "Micolta", PlayerPosition.Defender, 13),
                ("Diego", "Peralta", PlayerPosition.Defender, 6),
                ("Ray", "Vanegas", PlayerPosition.Midfielder, 10),
                ("Daniel", "Hernández", PlayerPosition.Midfielder, 8),
                ("Kevin", "Rendón", PlayerPosition.Midfielder, 5),
                ("Jown", "Cardona", PlayerPosition.Midfielder, 14),
                ("Jown", "Cardona", PlayerPosition.Forward, 9),
                ("Carlos", "Rodríguez", PlayerPosition.Forward, 7),
                ("Jeison", "Medina", PlayerPosition.Forward, 11),
                ("Óscar", "Hernández", PlayerPosition.Forward, 17),
            },

            // 12. Deportivo Pereira
            new[] {
                ("Harlen", "Castillo", PlayerPosition.Goalkeeper, 1),
                ("Carlos", "Bejarano", PlayerPosition.Goalkeeper, 12),
                ("David", "González", PlayerPosition.Defender, 3),
                ("Jhonatan", "Pérez", PlayerPosition.Defender, 4),
                ("Brayan", "León", PlayerPosition.Defender, 13),
                ("Maicol", "Balanta", PlayerPosition.Defender, 6),
                ("Brayan", "León", PlayerPosition.Midfielder, 8),
                ("Leonardo", "Castro", PlayerPosition.Midfielder, 5),
                ("Jhonatan", "Pérez", PlayerPosition.Midfielder, 10),
                ("Yeison", "Guzmán", PlayerPosition.Midfielder, 14),
                ("Jonier", "Mosquera", PlayerPosition.Forward, 9),
                ("Michael", "Barrios", PlayerPosition.Forward, 7),
                ("Cristian", "Marrugo", PlayerPosition.Forward, 11),
                ("Mateo", "Sierra", PlayerPosition.Forward, 17),
            },

            // 13. Águilas Doradas
            new[] {
                ("José Fernando", "Cuadrado", PlayerPosition.Goalkeeper, 1),
                ("Juan David", "Valencia", PlayerPosition.Goalkeeper, 12),
                ("Éder", "Chaux", PlayerPosition.Defender, 4),
                ("David", "Camacho", PlayerPosition.Defender, 3),
                ("Óscar", "Cabezas", PlayerPosition.Defender, 13),
                ("Hayen", "Palacios", PlayerPosition.Defender, 6),
                ("Juan Pablo", "Ramírez", PlayerPosition.Midfielder, 10),
                ("Mauricio", "Castaño", PlayerPosition.Midfielder, 8),
                ("Leonardo", "Saldaña", PlayerPosition.Midfielder, 5),
                ("David", "Montoya", PlayerPosition.Midfielder, 14),
                ("Cristian", "Subero", PlayerPosition.Forward, 9),
                ("Brayan", "Gil", PlayerPosition.Forward, 7),
                ("Juan", "Ferney", PlayerPosition.Forward, 11),
                ("Edwar", "López", PlayerPosition.Forward, 17),
            },

            // 14. Boyacá Chicó FC
            new[] {
                ("Ernesto", "Hernández", PlayerPosition.Goalkeeper, 1),
                ("Jhon", "Jairo González", PlayerPosition.Goalkeeper, 12),
                ("Carlos", "Henao", PlayerPosition.Defender, 3),
                ("Jean", "Blanco", PlayerPosition.Defender, 4),
                ("Félix", "Charrupí", PlayerPosition.Defender, 13),
                ("Jhon", "Fredy Navia", PlayerPosition.Defender, 6),
                ("Brayan", "Moreno", PlayerPosition.Midfielder, 8),
                ("Michel", "López", PlayerPosition.Midfielder, 5),
                ("Johan", "Caballero", PlayerPosition.Midfielder, 10),
                ("Estefano", "Arango", PlayerPosition.Midfielder, 14),
                ("Juan David", "Valencia", PlayerPosition.Forward, 9),
                ("Nicolás", "Palacios", PlayerPosition.Forward, 7),
                ("Robinson", "Aponzá", PlayerPosition.Forward, 11),
                ("Yulián", "Anchico", PlayerPosition.Forward, 17),
            },

            // 15. Jaguares de Córdoba
            new[] {
                ("Diego", "Novoa", PlayerPosition.Goalkeeper, 1),
                ("José Luis", "Chunga", PlayerPosition.Goalkeeper, 12),
                ("Geovan", "Montes", PlayerPosition.Defender, 4),
                ("Yulián", "Anchico", PlayerPosition.Defender, 3),
                ("Danilo", "Arboleda", PlayerPosition.Defender, 13),
                ("Jéfferson", "Mena", PlayerPosition.Defender, 6),
                ("Larry", "Vásquez", PlayerPosition.Midfielder, 5),
                ("Pablo", "Bueno", PlayerPosition.Midfielder, 8),
                ("Sebastián", "Macías", PlayerPosition.Midfielder, 10),
                ("Fabry", "Castro", PlayerPosition.Midfielder, 14),
                ("Pablo", "Bueno", PlayerPosition.Forward, 9),
                ("Luis", "Miranda", PlayerPosition.Forward, 7),
                ("Jaminton", "Campaz", PlayerPosition.Forward, 11),
                ("Yesid", "Díaz", PlayerPosition.Forward, 17),
            },

            // 16. Alianza Valledupar FC
            new[] {
                ("Luis", "Delgado", PlayerPosition.Goalkeeper, 1),
                ("Ernesto", "Pérez", PlayerPosition.Goalkeeper, 12),
                ("Marvin", "Vallecilla", PlayerPosition.Defender, 3),
                ("César", "Arias", PlayerPosition.Defender, 4),
                ("Fabio", "Burbano", PlayerPosition.Defender, 13),
                ("Alex", "Rambal", PlayerPosition.Defender, 6),
                ("Juan", "Sánchez", PlayerPosition.Midfielder, 8),
                ("Mateo", "García", PlayerPosition.Midfielder, 5),
                ("Jhonatan", "Lopera", PlayerPosition.Midfielder, 10),
                ("Carlos", "Valencia", PlayerPosition.Midfielder, 14),
                ("Jeison", "Medina", PlayerPosition.Forward, 9),
                ("Robinson", "Zapata", PlayerPosition.Forward, 7),
                ("Brayan", "Angulo", PlayerPosition.Forward, 11),
                ("Kevin", "Salazar", PlayerPosition.Forward, 17),
            },

            // 17. Fortaleza FC
            new[] {
                ("Carlos", "Mosquera", PlayerPosition.Goalkeeper, 1),
                ("Diego", "Alejandro Martínez", PlayerPosition.Goalkeeper, 12),
                ("Nicolás", "Giraldo", PlayerPosition.Defender, 4),
                ("Santiago", "Ruiz", PlayerPosition.Defender, 3),
                ("Brayan", "Morales", PlayerPosition.Defender, 13),
                ("Diego", "Chica", PlayerPosition.Defender, 6),
                ("Jhonier", "Viveros", PlayerPosition.Midfielder, 10),
                ("Mateo", "Carvajal", PlayerPosition.Midfielder, 8),
                ("Santiago", "Montoya", PlayerPosition.Midfielder, 5),
                ("Kevin", "Agudelo", PlayerPosition.Midfielder, 14),
                ("Óscar", "Vanegas", PlayerPosition.Forward, 9),
                ("Daniel", "Cataño", PlayerPosition.Forward, 7),
                ("Jhon", "Vásquez", PlayerPosition.Forward, 11),
                ("Brayan", "Perea", PlayerPosition.Forward, 17),
            },

            // 18. Llaneros FC
            new[] {
                ("José Huber", "Escobar", PlayerPosition.Goalkeeper, 1),
                ("Cristian", "Vargas", PlayerPosition.Goalkeeper, 12),
                ("Cristian", "Arrieta", PlayerPosition.Defender, 3),
                ("Daniel", "Torres", PlayerPosition.Defender, 4),
                ("Yeison", "Gordillo", PlayerPosition.Defender, 13),
                ("Santiago", "Orozco", PlayerPosition.Defender, 6),
                ("Jhon", "Pajoy", PlayerPosition.Midfielder, 8),
                ("Andrés", "Ramírez", PlayerPosition.Midfielder, 5),
                ("Luis", "Payares", PlayerPosition.Midfielder, 10),
                ("Diego", "Sánchez", PlayerPosition.Midfielder, 14),
                ("Brayan", "Gil", PlayerPosition.Forward, 9),
                ("Michael", "López", PlayerPosition.Forward, 7),
                ("Jhon", "Jairo Mosquera", PlayerPosition.Forward, 11),
                ("Oscar", "Estupiñán", PlayerPosition.Forward, 17),
            },

            // 19. Cúcuta Deportivo
            new[] {
                ("Norberto", "Araujo", PlayerPosition.Goalkeeper, 1),
                ("Luis", "Fernando Vega", PlayerPosition.Goalkeeper, 12),
                ("Jefry", "Díaz", PlayerPosition.Defender, 4),
                ("Carlos", "Ramírez", PlayerPosition.Defender, 3),
                ("Nilson", "Castrillón", PlayerPosition.Defender, 13),
                ("Breiner", "Paz", PlayerPosition.Defender, 6),
                ("Juan Camilo", "Portilla", PlayerPosition.Midfielder, 10),
                ("Harrinson", "Mancilla", PlayerPosition.Midfielder, 8),
                ("Sebastián", "Salazar", PlayerPosition.Midfielder, 5),
                ("Javier", "Reina", PlayerPosition.Midfielder, 14),
                ("Edwar", "López", PlayerPosition.Forward, 9),
                ("Yuber", "Asprilla", PlayerPosition.Forward, 7),
                ("Brayan", "Fernández", PlayerPosition.Forward, 11),
                ("Robinson", "Aponzá", PlayerPosition.Forward, 17),
            },

            // 20. Internacional de Bogotá
            new[] {
                ("Neto", "Volpi", PlayerPosition.Goalkeeper, 1),
                ("Diego", "Moreno", PlayerPosition.Goalkeeper, 12),
                ("Nicolás", "Hernández", PlayerPosition.Defender, 3),
                ("Julián", "Millán", PlayerPosition.Defender, 4),
                ("Cristian", "Zapata", PlayerPosition.Defender, 13),
                ("Harold", "Santiago", PlayerPosition.Defender, 6),
                ("Carlos Darwin", "Quintero", PlayerPosition.Midfielder, 10),
                ("Jhon", "Arias", PlayerPosition.Midfielder, 8),
                ("Gustavo", "Cuéllar", PlayerPosition.Midfielder, 5),
                ("Yimmi", "Chará", PlayerPosition.Midfielder, 14),
                ("Facundo", "Boné", PlayerPosition.Forward, 9),
                ("Rafael Santos", "Borré", PlayerPosition.Forward, 7),
                ("Luis", "Díaz", PlayerPosition.Forward, 11),
                ("Jhon", "Durán", PlayerPosition.Forward, 17),
            },
        };

        var players = new List<Player>();
        for (int i = 0; i < teams.Count; i++)
        {
            foreach (var pd in playersData[i])
            {
                players.Add(new Player
                {
                    FirstName = pd.First,
                    LastName = pd.Last,
                    Number = pd.Number,
                    Position = pd.Pos,
                    BirthDate = new DateTime(1995, 1, 1).AddMonths(players.Count),
                    TeamId = teams[i].Id
                });
            }
        }
        context.Players.AddRange(players);
        await context.SaveChangesAsync();

        // ═══ 3. ÁRBITROS ═══
        var referees = new List<Referee>
        {
            new() { FirstName="Wilmar", LastName="Roldán", Nationality="Colombia" },
            new() { FirstName="Andrés", LastName="Rojas", Nationality="Colombia" },
            new() { FirstName="Carlos", LastName="Betancur", Nationality="Colombia" },
            new() { FirstName="Jhon", LastName="Hinestroza", Nationality="Colombia" },
        };
        context.Referees.AddRange(referees);
        await context.SaveChangesAsync();

        // ═══ 4. TORNEO ═══
        var tournament = new Tournament
        {
            Name = "Liga BetPlay 2026-I",
            Season = "2026-I",
            StartDate = new DateTime(2026, 1, 16),
            EndDate = new DateTime(2026, 6, 5),
            Status = TournamentStatus.InProgress
        };
        context.Tournaments.Add(tournament);
        await context.SaveChangesAsync();

        // ═══ 5. INSCRIBIR LOS 20 EQUIPOS ═══
        foreach (var team in teams)
        {
            context.TournamentTeams.Add(new TournamentTeam
            {
                TournamentId = tournament.Id,
                TeamId = team.Id
            });
        }
        await context.SaveChangesAsync();

        // ══ 6. PARTIDOS (Fecha 1 de la Liga BetPlay) ══
        // Creamos partidos entre equipos ya inscritos.
        // Todos en estado Scheduled para poder registrar alineaciones (V6).
        // teams[0] = Atlético Nacional, teams[1] = Independiente Medellín, etc.

        var matches = new List<Match>
        {
            // Fecha 1 - Clásico Paisa
            new()
            {
                TournamentId = tournament.Id,
                HomeTeamId = teams[0].Id,    // Atlético Nacional
                AwayTeamId = teams[1].Id,    // Independiente Medellín
                RefereeId = referees[0].Id,  // Wilmar Roldán
                MatchDate = new DateTime(2026, 2, 1, 18, 0, 0),
                Venue = "Atanasio Girardot",
                Matchday = 1,
                Status = MatchStatus.Scheduled  // IMPORTANTE: debe ser Scheduled para V6
            },

            // Fecha 1 - Cali vs Deportivo Cali
            new()
            {
                TournamentId = tournament.Id,
                HomeTeamId = teams[2].Id,    // América de Cali
                AwayTeamId = teams[3].Id,    // Deportivo Cali
                RefereeId = referees[1].Id,  // Andrés Rojas
                MatchDate = new DateTime(2026, 2, 1, 20, 0, 0),
                Venue = "Pascual Guerrero",
                Matchday = 1,
                Status = MatchStatus.Scheduled
            },

            // Fecha 1 - Junior vs Millonarios
            new()
            {
                TournamentId = tournament.Id,
                HomeTeamId = teams[4].Id,    // Junior FC
                AwayTeamId = teams[5].Id,    // Millonarios FC
                RefereeId = referees[2].Id,  // Carlos Betancur
                MatchDate = new DateTime(2026, 2, 2, 16, 0, 0),
                Venue = "Metropolitano",
                Matchday = 1,
                Status = MatchStatus.Scheduled
            },
        };

        context.Matches.AddRange(matches);
        await context.SaveChangesAsync();


        // ══ 7. ALINEACIONES (MatchLineups) ══
        // Recargamos los jugadores con sus IDs reales
        var allPlayers = await context.Players
            .OrderBy(p => p.TeamId)
            .ThenBy(p => p.Number)
            .ToListAsync();

        // Helper: obtener jugadores de un equipo
        List<Player> GetTeamPlayers(int teamId) =>
            allPlayers.Where(p => p.TeamId == teamId).ToList();

        // Posiciones tácticas para 14 jugadores (11 titulares + 3 suplentes)
        string[] positions14 = { "GK", "CB", "CB", "LB", "RB", "CDM", "CM", "CAM", "LW", "RW", "ST", "GK", "CM", "ST" };

        var lineups = new List<MatchLineup>();

        // ── Partido 1: Nacional (14) vs Medellín (14) ──
        // Ambos equipos tienen 14 jugadores → 11 titulares + 3 suplentes
        var match1 = matches[0];

        var nacionalPlayers = GetTeamPlayers(teams[0].Id);
        for (int j = 0; j < nacionalPlayers.Count; j++)
        {
            lineups.Add(new MatchLineup
            {
                MatchId = match1.Id,
                PlayerId = nacionalPlayers[j].Id,
                IsStarter = j < 11,    // Primeros 11 = titulares, últimos 3 = suplentes
                Position = positions14[j]
            });
        }

        var medellinPlayers = GetTeamPlayers(teams[1].Id);
        for (int j = 0; j < medellinPlayers.Count; j++)
        {
            lineups.Add(new MatchLineup
            {
                MatchId = match1.Id,
                PlayerId = medellinPlayers[j].Id,
                IsStarter = j < 11,
                Position = positions14[j]
            });
        }

        // ── Partido 2: América (14) vs Deportivo Cali (14) ──
        // 11 titulares + 3 suplentes cada uno
        var match2 = matches[1];

        var americaPlayers = GetTeamPlayers(teams[2].Id);
        for (int j = 0; j < americaPlayers.Count; j++)
        {
            lineups.Add(new MatchLineup
            {
                MatchId = match2.Id,
                PlayerId = americaPlayers[j].Id,
                IsStarter = j < 11,
                Position = positions14[j]
            });
        }

        var caliPlayers = GetTeamPlayers(teams[3].Id);
        for (int j = 0; j < caliPlayers.Count; j++)
        {
            lineups.Add(new MatchLineup
            {
                MatchId = match2.Id,
                PlayerId = caliPlayers[j].Id,
                IsStarter = j < 11,
                Position = positions14[j]
            });
        }

        // ── Partido 3: Junior vs Millonarios ──
        // SIN alineaciones → para probar POST manualmente en Swagger

        context.MatchLineups.AddRange(lineups);
        await context.SaveChangesAsync();
    }
}