using JuniorPower.Models;
using System.Text.Json;

namespace JuniorPower.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.StudyDays.Any()) return;

        var days = new List<StudyDay>
        {
            new StudyDay
            {
                DayNumber = 1,
                Title = "Bases Reales de Programación",
                Description = "Hoy no usas frameworks ni AI. Hoy entiendes el código real.",
                Icon = "💻",
                DayGoal = "Entender completamente el flujo del código. Si no puedes explicar cada línea, no la escribas.",
                Objectives = JsonSerializer.Serialize(new[]
                {
                    "Entender variables, tipos y memoria",
                    "Dominar condicionales y loops",
                    "Escribir funciones reales",
                    "Manejar arrays y objetos",
                    "Manejar errores sin pánico",
                    "Debuggear paso a paso"
                }),
                Topics = JsonSerializer.Serialize(new[]
                {
                    "Variables y tipos de datos",
                    "Condicionales (if/else/switch)",
                    "Loops (for, while, foreach)",
                    "Funciones y parámetros",
                    "Arrays y listas",
                    "Objetos y clases básicas",
                    "Try/catch y manejo de errores",
                    "Debugging con breakpoints"
                }),
                ProjectName = "Sistema de Tareas en Consola",
                ProjectDescription = "Crea un sistema de tareas en consola SIN Google, SIN AI. Solo tú y el código. Debe permitir agregar, listar, completar y eliminar tareas.",
                ErrorsToProvoke = JsonSerializer.Serialize(new[]
                {
                    "NullReferenceException: accede a un objeto sin inicializarlo",
                    "Loop infinito: olvida incrementar el contador",
                    "IndexOutOfRange: accede a índice inexistente en array",
                    "Tipo incorrecto: suma string con número",
                    "Variable no definida: usa variable antes de declararla"
                })
            },
            new StudyDay
            {
                DayNumber = 2,
                Title = "Backend y APIs REST",
                Description = "El mundo real funciona con APIs. Hoy aprendes a construirlas.",
                Icon = "🌐",
                DayGoal = "Entender cómo funciona HTTP y REST de verdad, no solo copiar endpoints.",
                Objectives = JsonSerializer.Serialize(new[]
                {
                    "Entender HTTP completo (métodos, headers, body)",
                    "Construir una API REST desde cero",
                    "Entender JSON y serialización",
                    "Manejar status codes correctamente",
                    "Testear con curl o Postman"
                }),
                Topics = JsonSerializer.Serialize(new[]
                {
                    "HTTP: GET, POST, PUT, DELETE",
                    "Status codes: 200, 201, 400, 404, 500",
                    "JSON: serialización y deserialización",
                    "REST: convenciones y buenas prácticas",
                    "Controllers en ASP.NET Core",
                    "Validación de datos de entrada",
                    "Middleware básico",
                    "Testing con curl desde terminal"
                }),
                ProjectName = "CRUD de Usuarios",
                ProjectDescription = "API REST completa para gestionar usuarios. Sin frontend. Solo endpoints. Testea cada uno con curl desde la terminal.",
                ErrorsToProvoke = JsonSerializer.Serialize(new[]
                {
                    "404 Not Found: ruta mal escrita o método incorrecto",
                    "400 Bad Request: JSON inválido en el body",
                    "500 Internal Server Error: excepción no manejada",
                    "405 Method Not Allowed: POST a endpoint GET",
                    "Null body: olvidar [FromBody] en el parámetro"
                })
            },
            new StudyDay
            {
                DayNumber = 3,
                Title = "Bases de Datos Reales",
                Description = "Los datos deben persistir. Hoy aprendes a guardarlos de verdad.",
                Icon = "🗄️",
                DayGoal = "Entender persistencia real. Cada dato tiene que sobrevivir un restart.",
                Objectives = JsonSerializer.Serialize(new[]
                {
                    "Entender tablas, columnas y tipos SQL",
                    "Dominar SELECT, INSERT, UPDATE, DELETE",
                    "Entender relaciones y foreign keys",
                    "Usar Entity Framework Core",
                    "Escribir queries complejas con joins"
                }),
                Topics = JsonSerializer.Serialize(new[]
                {
                    "SQLite: instalación y uso básico",
                    "SQL: CREATE TABLE, SELECT, INSERT, UPDATE, DELETE",
                    "Relaciones: 1:1, 1:N, N:M",
                    "JOINs: INNER, LEFT, RIGHT",
                    "Entity Framework Core: DbContext, DbSet",
                    "Migrations: crear y aplicar",
                    "LINQ: consultas en C#",
                    "Índices y optimización básica"
                }),
                ProjectName = "CRUD con SQLite",
                ProjectDescription = "Conecta el CRUD del Día 2 a SQLite. Los datos deben persistir entre reinicios. Implementa búsqueda y filtrado.",
                ErrorsToProvoke = JsonSerializer.Serialize(new[]
                {
                    "Conexión fallida: string de conexión incorrecta",
                    "Migration error: cambiar modelo sin nueva migration",
                    "Null reference: relación no cargada (Include faltante)",
                    "Unique constraint: insertar dato duplicado",
                    "Lazy loading: N+1 queries sin Include"
                })
            },
            new StudyDay
            {
                DayNumber = 4,
                Title = "Linux y Git",
                Description = "Los developers reales viven en la terminal. Hoy te mudas ahí.",
                Icon = "🐧",
                DayGoal = "Trabajar como developer real: terminal, Git, GitHub sin GUI.",
                Objectives = JsonSerializer.Serialize(new[]
                {
                    "Dominar comandos Linux esenciales",
                    "Entender procesos, puertos y logs",
                    "Usar Git sin GUI (solo terminal)",
                    "Subir proyecto a GitHub",
                    "Resolver conflictos Git"
                }),
                Topics = JsonSerializer.Serialize(new[]
                {
                    "Linux: ls, cd, mkdir, rm, cp, mv, cat, grep",
                    "Procesos: ps, kill, top, htop",
                    "Puertos: netstat, lsof, ss",
                    "Logs: tail -f, journalctl, less",
                    "Permisos: chmod, chown",
                    "Variables de entorno: export, .env",
                    "Git: init, add, commit, push, pull",
                    "Git: branch, merge, rebase, stash",
                    "GitHub: repositorios, SSH keys"
                }),
                ProjectName = "Proyecto en GitHub",
                ProjectDescription = "Sube el proyecto del Día 3 a GitHub desde terminal. Crea branches, haz commits descriptivos, resuelve un conflicto real.",
                ErrorsToProvoke = JsonSerializer.Serialize(new[]
                {
                    "Merge conflict: editar mismo archivo en 2 branches",
                    "Permission denied: archivo sin permisos de ejecución",
                    "Port already in use: proceso corriendo en el mismo puerto",
                    "Push rejected: pull antes de push",
                    "Detached HEAD: checkout a commit específico"
                })
            },
            new StudyDay
            {
                DayNumber = 5,
                Title = "Docker",
                Description = "Tu código debe correr en cualquier máquina. Docker lo hace posible.",
                Icon = "🐳",
                DayGoal = "Dockerizar tu aplicación y que corra igual en cualquier ambiente.",
                Objectives = JsonSerializer.Serialize(new[]
                {
                    "Entender contenedores vs máquinas virtuales",
                    "Crear un Dockerfile correcto",
                    "Usar Docker Compose",
                    "Gestionar volúmenes y redes",
                    "Debuggear contenedores caídos"
                }),
                Topics = JsonSerializer.Serialize(new[]
                {
                    "Docker: imágenes, contenedores, layers",
                    "Dockerfile: FROM, RUN, COPY, ENV, EXPOSE, CMD",
                    "Docker Compose: servicios, redes, volúmenes",
                    "Comandos: build, run, ps, logs, exec, stop",
                    "Redes Docker: bridge, host",
                    "Volúmenes: persistencia en contenedores",
                    "Variables de entorno en Docker",
                    "Multi-stage builds básico"
                }),
                ProjectName = "Dockerizar Aplicación",
                ProjectDescription = "Dockeriza la aplicación completa. Debe correr con 'docker compose up' sin configuración adicional. La DB debe persistir entre reinicios.",
                ErrorsToProvoke = JsonSerializer.Serialize(new[]
                {
                    "Container exits immediately: CMD incorrecto en Dockerfile",
                    "Port not accessible: EXPOSE faltante o -p incorrecto",
                    "DB not persisting: volumen no configurado",
                    "Build fails: dependencias no copiadas correctamente",
                    "Cannot connect to DB: networking entre contenedores mal"
                })
            },
            new StudyDay
            {
                DayNumber = 6,
                Title = "Debugging y Troubleshooting",
                Description = "Los errores no son el problema. No saber resolverlos sí lo es.",
                Icon = "🔍",
                DayGoal = "Resolver cualquier error sin pánico. Metodología > suerte.",
                Objectives = JsonSerializer.Serialize(new[]
                {
                    "Leer stack traces como un profesional",
                    "Usar logs para diagnóstico",
                    "Debuggear paso a paso con breakpoints",
                    "Reproducir errores consistentemente",
                    "Resolver errores sin buscar en Google inmediatamente"
                }),
                Topics = JsonSerializer.Serialize(new[]
                {
                    "Stack traces: cómo leerlos de abajo hacia arriba",
                    "Logging: niveles, ILogger, Serilog básico",
                    "Breakpoints en Rider/VS Code",
                    "Watch variables y call stack",
                    "curl y Postman para debuggear APIs",
                    "docker logs y docker exec para contenedores",
                    "Health checks básicos",
                    "Metodología de debugging: divide y conquista"
                }),
                ProjectName = "Resolver Errores Intencionales",
                ProjectDescription = "Se te dará una aplicación con 10 bugs reales. Debes resolverlos TODOS sin AI. Solo logs, breakpoints y tu cerebro.",
                ErrorsToProvoke = JsonSerializer.Serialize(new[]
                {
                    "DB caída: connection string a BD que no existe",
                    "Docker roto: imagen con CMD que falla silenciosamente",
                    "Variable de entorno faltante: config que el código asume",
                    "Puerto ocupado: otro proceso en el mismo puerto",
                    "Deadlock de base de datos: transacción mal manejada",
                    "Memory leak: objeto grande nunca liberado",
                    "Race condition: async sin await",
                    "Encoding error: caracteres especiales no manejados"
                })
            },
            new StudyDay
            {
                DayNumber = 7,
                Title = "Proyecto Final",
                Description = "Todo lo que aprendiste en una semana, en un proyecto real.",
                Icon = "🚀",
                DayGoal = "Construir un backend completo que demuestre que eres un junior sólido.",
                Objectives = JsonSerializer.Serialize(new[]
                {
                    "Backend completo con todas las capas",
                    "Docker funcionando perfectamente",
                    "Git con historial limpio y descriptivo",
                    "Manejo de errores profesional",
                    "Documentación básica en README",
                    "API consumiendo servicio externo"
                }),
                Topics = JsonSerializer.Serialize(new[]
                {
                    "Integración de todo lo aprendido",
                    "CRUD completo con validaciones",
                    "SQLite con EF Core migrations",
                    "Docker Compose multi-servicio",
                    "Logs estructurados",
                    "Consumir API externa (OpenWeather, JSONPlaceholder)",
                    "README profesional en GitHub",
                    "Simulación de code review"
                }),
                ProjectName = "Backend Junior Completo",
                ProjectDescription = "API REST completa de gestión de proyectos. Con autenticación básica, validaciones, logging, Docker, SQLite y consumo de API externa. Sube a GitHub con README.",
                ErrorsToProvoke = JsonSerializer.Serialize(new[]
                {
                    "Sin errores intencionales: aquí debes resolver los que tú mismo cometas",
                    "Code review: otro desarrollador revisa tu código",
                    "Presentación: explica cada decisión técnica"
                })
            }
        };

        context.StudyDays.AddRange(days);
        context.SaveChanges();

        var tasks = new List<StudyTask>();
        var taskData = GetTasksPerDay();

        foreach (var day in context.StudyDays.ToList())
        {
            if (taskData.TryGetValue(day.DayNumber, out var dayTasks))
            {
                for (int i = 0; i < dayTasks.Count; i++)
                {
                    var (title, description, category) = dayTasks[i];
                    tasks.Add(new StudyTask
                    {
                        StudyDayId = day.Id,
                        Title = title,
                        Description = description,
                        Category = category,
                        OrderIndex = i + 1,
                        IsCompleted = false
                    });
                }
            }
        }

        context.StudyTasks.AddRange(tasks);
        context.SaveChanges();
    }

    private static Dictionary<int, List<(string title, string description, TaskCategory category)>> GetTasksPerDay()
    {
        return new Dictionary<int, List<(string, string, TaskCategory)>>
        {
            [1] = new()
            {
                ("Leer: Variables y tipos de datos", "Lee la documentación oficial de C#. No AI. Solo docs.", TaskCategory.Reading),
                ("Ejercicio: Calculadora sin AI", "Crea calculadora con suma, resta, multiplicación y división usando solo funciones.", TaskCategory.Exercise),
                ("Ejercicio: Provoca NullReferenceException", "Escribe código que lance este error, entiende POR QUÉ ocurre.", TaskCategory.Exercise),
                ("Ejercicio: Loop infinito intencional", "Créalo, entiéndelo, corrígelo. Sin buscar en Google.", TaskCategory.Exercise),
                ("Proyecto: Sistema de tareas en consola", "CRUD completo en consola. Agregar, listar, completar, eliminar.", TaskCategory.Project),
                ("Debug: Explica cada línea de tu proyecto", "Si no puedes explicarla, reescríbela hasta entenderla.", TaskCategory.Practice),
                ("Reflexión: ¿Qué fue lo más difícil?", "Escribe en papel qué costó más trabajo y por qué.", TaskCategory.Practice)
            },
            [2] = new()
            {
                ("Leer: HTTP completo (MDN Web Docs)", "Lee sobre métodos, headers, body, status codes. Sin saltar partes.", TaskCategory.Reading),
                ("Instalar y explorar Postman o usar curl", "Haz requests a apis públicas. JSONPlaceholder es gratis.", TaskCategory.Exercise),
                ("Crear endpoint GET /usuarios", "Retorna lista de usuarios hardcodeados. Sin DB todavía.", TaskCategory.Practice),
                ("Crear endpoint POST /usuarios", "Recibe JSON, valida, retorna el usuario creado con 201.", TaskCategory.Practice),
                ("Crear endpoint PUT /usuarios/{id}", "Actualiza usuario. Retorna 404 si no existe.", TaskCategory.Practice),
                ("Crear endpoint DELETE /usuarios/{id}", "Elimina usuario. Retorna 204. Maneja 404.", TaskCategory.Practice),
                ("Provocar error 500 intencional", "Lanza excepción sin manejar. Lee el stack trace completo.", TaskCategory.Exercise),
                ("Testear TODOS los endpoints con curl", "Sin Postman. Solo terminal. Guarda los comandos.", TaskCategory.Project)
            },
            [3] = new()
            {
                ("Instalar DB Browser for SQLite", "Herramienta visual para ver la DB. Úsala para verificar datos.", TaskCategory.Practice),
                ("Crear schema SQL a mano", "Escribe el CREATE TABLE a mano. Sin EF Core todavía.", TaskCategory.Exercise),
                ("Ejercicio: 10 queries SQL a mano", "SELECT con WHERE, JOIN, GROUP BY, ORDER BY. Sin ORM.", TaskCategory.Exercise),
                ("Configurar EF Core en el proyecto", "DbContext, connection string, DbSet. Entiende cada línea.", TaskCategory.Practice),
                ("Crear y aplicar primera Migration", "dotnet ef migrations add. Lee el archivo generado.", TaskCategory.Practice),
                ("Conectar API del Día 2 a SQLite", "Reemplaza datos hardcodeados con EF Core real.", TaskCategory.Project),
                ("Implementar búsqueda con LINQ", "Filtrar por nombre, email. Entender IQueryable.", TaskCategory.Practice),
                ("Provocar error N+1 queries", "Crea relación sin Include. Mira las queries en logs.", TaskCategory.Exercise)
            },
            [4] = new()
            {
                ("Memorizar 20 comandos Linux básicos", "Sin cheatsheet. Solo memoria. Los usarás todos los días.", TaskCategory.Reading),
                ("Ejercicio: navegar filesystem solo con terminal", "No toques el mouse. Solo comandos.", TaskCategory.Exercise),
                ("Ver logs de tu aplicación en tiempo real", "tail -f. Aprende a leer logs mientras la app corre.", TaskCategory.Practice),
                ("Encontrar proceso usando un puerto", "lsof -i :5000. Matar proceso con kill.", TaskCategory.Exercise),
                ("git init y primer commit", "Desde terminal. Mensaje de commit descriptivo de verdad.", TaskCategory.Practice),
                ("Crear branch 'feature/search'", "Implementa búsqueda, merge a main. Todo desde terminal.", TaskCategory.Practice),
                ("Provocar merge conflict y resolverlo", "Edita mismo archivo en 2 branches. Resuelve a mano.", TaskCategory.Exercise),
                ("Subir proyecto a GitHub", "Con SSH keys. README básico. Push desde terminal.", TaskCategory.Project)
            },
            [5] = new()
            {
                ("Leer: ¿Qué es Docker y por qué existe?", "Entiende el problema que resuelve antes de usar la herramienta.", TaskCategory.Reading),
                ("Instalar Docker y correr hello-world", "docker run hello-world. Lee qué hace cada línea del output.", TaskCategory.Exercise),
                ("Explorar imagen oficial de .NET", "docker pull mcr.microsoft.com/dotnet/sdk:8.0. Examínala.", TaskCategory.Practice),
                ("Escribir Dockerfile para tu app", "FROM, COPY, RUN, EXPOSE, CMD. Sin copiar de internet.", TaskCategory.Practice),
                ("Build y run del contenedor", "docker build -t juniorpower . && docker run -p 5000:5000 juniorpower", TaskCategory.Practice),
                ("Crear docker-compose.yml", "App + SQLite con volumen. docker compose up debe funcionar.", TaskCategory.Project),
                ("Provocar contenedor caído", "CMD incorrecto. Lee logs. Corrige. Aprende el proceso.", TaskCategory.Exercise),
                ("Verificar persistencia de datos", "Restart el contenedor. Los datos deben seguir ahí.", TaskCategory.Practice)
            },
            [6] = new()
            {
                ("Leer un stack trace completo en voz alta", "De abajo hacia arriba. Identifica el origen real del error.", TaskCategory.Reading),
                ("Configurar logging estructurado", "ILogger en todos los controllers. Levels: Info, Warning, Error.", TaskCategory.Practice),
                ("Debuggear con breakpoints en Rider", "Paso a paso. Watch variables. Call stack. Sin Console.WriteLine.", TaskCategory.Exercise),
                ("Resolver Bug #1: DB caída", "Encuentra por qué no conecta. Solo logs y código.", TaskCategory.Exercise),
                ("Resolver Bug #2: API retorna 500", "Lee el stack trace. Encuentra el null. Corrígelo.", TaskCategory.Exercise),
                ("Resolver Bug #3: Docker no levanta", "Logs del contenedor. Encuentra el error de startup.", TaskCategory.Exercise),
                ("Resolver Bug #4: Datos no persisten", "El volumen no está bien. Encuéntralo y corrígelo.", TaskCategory.Exercise),
                ("Escribir tu metodología de debugging", "Papel y lápiz. Tu proceso cuando algo falla. Para siempre.", TaskCategory.Practice)
            },
            [7] = new()
            {
                ("Diseñar la API en papel primero", "Endpoints, modelos, relaciones. Antes de escribir código.", TaskCategory.Practice),
                ("Implementar modelos y migrations", "Clean, descriptivos. Piensa en normalización.", TaskCategory.Practice),
                ("CRUD completo con validaciones", "FluentValidation o Data Annotations. Todos los casos.", TaskCategory.Project),
                ("Implementar logging profesional", "Request/response logging. Errores con contexto completo.", TaskCategory.Practice),
                ("Consumir API externa", "JSONPlaceholder o OpenWeatherMap. Maneja errores de red.", TaskCategory.Project),
                ("Docker Compose production-ready", "Variables de entorno. Volúmenes. Health checks.", TaskCategory.Project),
                ("Push a GitHub con historial limpio", "Commits descriptivos. No 'fix', no 'update'. Mensajes reales.", TaskCategory.Practice),
                ("Escribir README profesional", "Cómo correr el proyecto, endpoints, arquitectura, decisiones.", TaskCategory.Practice),
                ("Code Review simulado", "Revisa tu propio código como si fuera de otro. Escribe issues.", TaskCategory.Practice)
            }
        };
    }
}
