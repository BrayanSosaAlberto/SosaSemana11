using (var contextdb = new Context())
{
    foreach (var Item in contextdb.estudiante)
    {
        Console.WriteLine($"Datos: Id: {Item.Id}, Nombre: {Item.Nombre}, Apellidos: {Item.Apellidos}, Edad: {Item.Edad}, Sexo: {Item.Sexo}");

    }
}

bool AgregarRegistros = true;

while (AgregarRegistros)
{
    Console.WriteLine("Por favor ingresar los datos del estudiante:");

    Console.Write("Nombre: ");
    string Nombre = Console.ReadLine();

    Console.Write("Apellidos: ");
    string Apellidos = Console.ReadLine();

    Console.Write("Sexo: ");
    string Sexo = Console.ReadLine();

    Console.Write("Edad: ");
    int Edad = Convert.ToInt32(Console.ReadLine());

    using (var contextdb = new Context())
    {
        contextdb.Database.EnsureCreated();

        var newEstudiante = new Student()
        {
            Nombre = Nombre,
            Apellidos = Apellidos,
            Sexo = Sexo,
            Edad = Edad
        };

        contextdb.Add(newEstudiante);
        contextdb.SaveChanges();
    }

    Console.WriteLine("¿Quiere seguir agregagando más registros? (Sí-No)");
    string Larespuesta = Console.ReadLine();
    AgregarRegistros = Larespuesta.StartsWith("S", StringComparison.OrdinalIgnoreCase);
}

using (var contextdb = new Context())
{
    foreach (var student in contextdb.estudiante)
    {
        Console.WriteLine($"Estudiante: {student.Nombre} {student.Apellidos}, Sexo: {student.Sexo}, Edad: {student.Edad}");
    }
}