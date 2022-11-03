using DAL.Modelo;

namespace BdFirst
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<entityBasicoContext>();
            context.Database.EnsureCreated();
            AddEmpleados(context);
        }

        private static void AddEmpleados(entityBasicoContext context)
        {
            var empleado = context.Empleado.FirstOrDefault();
            if (empleado != null) return;
            context.Empleado.Add(new Empleado
            {
                Id=40,
                NombreEmpleado= "Francisco"
            });

            context.SaveChanges();
        }


        
    }
}
