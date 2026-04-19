using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Trabalho_Daniel_Locadora_veiculo.Data;
using Trabalho_Daniel_Locadora_veiculo.Models;

namespace Trabalho_Daniel_Locadora_veiculo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers()
    .       AddJsonOptions(options =>
            {
            options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Locadora do Daniel", Version = "v1" });

                // Configuração para ler o XML
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (!context.Clientes.Any())
                {
            
                    var cliente1 = new Cliente
                    {
                        Nome = "Daniel de Freitas Cunha",
                        CPF = "1565660",
                        Email = "1565660@sga.pucminas.com.br"
                    };

                    var cliente2 = new Cliente
                    {
                        Nome = "Ana Pereira",
                        CPF = "12345678900",
                        Email = "ana@gmail.com"
                    };

                    var cliente3 = new Cliente
                    {
                        Nome = "Carlos Silva",
                        CPF = "98765432100",
                        Email = "carlos@gmail.com"
                    };

                    var cliente4 = new Cliente
                    {
                        Nome = "Pamela Adrielly",
                        CPF = "91234958490",
                        Email = "pampam@gmail.com"
                    };

                    var cliente5 = new Cliente
                    {
                        Nome = "Claude Maria de Freitas Cunha",
                        CPF = "0187564123",
                        Email = "clau@gmail.com"
                    };

                    var cliente6 = new Cliente
                    {
                        Nome = "Mauricio Alves da Cunha",
                        CPF = "97235646531",
                        Email = "Mauricioa@gmail.com"
                    };

                    context.Clientes.AddRange(cliente1, cliente2, cliente3,cliente4,cliente5,cliente6);

               
                    var fabricante1 = new Fabricante { Nome = "Toyota",Pais = "Japão" };
                    var fabricante2 = new Fabricante { Nome = "Honda",Pais = "Japão" };
                    var fabricante3 = new Fabricante { Nome = "Ford", Pais = "EUA" };
                    var fabricante4 = new Fabricante { Nome = "FIAT",Pais = "Italia" };
                    var fabricante5 = new Fabricante { Nome = "chevrolet", Pais = "EUA" };

                    context.Fabricantes.AddRange(fabricante1, fabricante2, fabricante3,fabricante4,fabricante5);

                 
                    var categoria1 = new Categoria { Nome = "Econômico" };
                    var categoria2 = new Categoria { Nome = "SUV" };
                    var categoria3 = new Categoria { Nome = "Luxo" };
                    var categoria4 = new Categoria { Nome = "Esportivo" };
                    var categoria5 = new Categoria { Nome = "Passeio" };
                    var categoria6 = new Categoria { Nome = "Caminhonete" };

                    context.Categorias.AddRange(categoria1, categoria2, categoria3,categoria4,categoria5,categoria6);

                    context.SaveChanges();

                    
                    var veiculo1 = new Veiculo
                    {
                        Modelo = "Corolla",
                        Ano = 2022,
                        Quilometragem = 30000,
                        FabricanteId = fabricante1.Id,
                        CategoriaId = categoria1.Id
                    };

                    var veiculo2 = new Veiculo
                    {
                        Modelo = "HR-V",
                        Ano = 2023,
                        Quilometragem = 15000,
                        FabricanteId = fabricante2.Id,
                        CategoriaId = categoria2.Id
                    };

                    var veiculo3 = new Veiculo
                    {
                        Modelo = "Mustang",
                        Ano = 2021,
                        Quilometragem = 20000,
                        FabricanteId = fabricante3.Id,
                        CategoriaId = categoria3.Id
                    };

                    var veiculo4 = new Veiculo
                    {
                        Modelo = "FIAT - Palio economy",
                        Ano = 2010,
                        Quilometragem = 71000,
                        FabricanteId = fabricante4.Id,
                        CategoriaId = categoria1.Id
                    };

                    var veiculo5 = new Veiculo
                    {
                        Modelo = "Chevrolet - Onix Prisma",
                        Ano = 2020,
                        Quilometragem = 53000,
                        FabricanteId = fabricante5.Id,
                        CategoriaId = categoria5.Id
                    };

                    var veiculo6 = new Veiculo
                    {
                        Modelo = "Toyota - Hilux Cabine Dupla",
                        Ano = 2018,
                        Quilometragem = 12000,
                        FabricanteId = fabricante1.Id,
                        CategoriaId = categoria6.Id
                    };

                    context.Veiculos.AddRange(veiculo1, veiculo2, veiculo3,veiculo4,veiculo5,veiculo6);

                    context.SaveChanges();


                    var locacao1 = new LocacaoCarro
                    {
                        ClienteId = cliente1.Id,
                        VeiculoId = veiculo1.Id,
                        DataInicio = DateTime.Now,
                        DataFim = DateTime.Now.AddDays(3),
                        KmInicial = veiculo1.Quilometragem,
                        KmFinal = veiculo1.Quilometragem + 300,
                        ValorDiaria = 150,
                        ValorTotal = 450
                    };

                    var locacao2 = new LocacaoCarro
                    {
                        ClienteId = cliente2.Id,
                        VeiculoId = veiculo2.Id,
                        DataInicio = DateTime.Now,
                        DataFim = DateTime.Now.AddDays(2),
                        KmInicial = veiculo2.Quilometragem,
                        KmFinal = veiculo2.Quilometragem + 200,
                        ValorDiaria = 200,
                        ValorTotal = 400
                    };

                    var locacao3 = new LocacaoCarro
                    {
                        ClienteId = cliente3.Id,
                        VeiculoId = veiculo4.Id,
                        DataInicio = DateTime.Parse("20/03/2026"),
                        DataFim = DateTime.Now.AddDays(5),
                        KmInicial = veiculo2.Quilometragem,
                        KmFinal = veiculo2.Quilometragem + 100,
                        ValorDiaria = 50,
                        ValorTotal = 250
                    };

                    var locacao4 = new LocacaoCarro
                    {
                        ClienteId = cliente4.Id,
                        VeiculoId = veiculo2.Id,
                        DataInicio = DateTime.Parse("11/01/2026"),
                        DataFim = DateTime.Now.AddDays(1),
                        KmInicial = veiculo2.Quilometragem,
                        KmFinal = veiculo2.Quilometragem + 5,
                        ValorDiaria = 100,
                        ValorTotal = 200
                    };

                    var locacao5 = new LocacaoCarro
                    {
                        ClienteId = cliente5.Id,
                        VeiculoId = veiculo6.Id,
                        DataInicio = DateTime.Parse("30/09/2025"),
                        DataFim = DateTime.Now.AddDays(4),
                        KmInicial = veiculo2.Quilometragem,
                        KmFinal = veiculo2.Quilometragem + 5,
                        ValorDiaria = 100,
                        ValorTotal = 400
                    };

                    var locacao6 = new LocacaoCarro
                    {
                        ClienteId = cliente6.Id,
                        VeiculoId = veiculo4.Id,
                        DataInicio = DateTime.Parse("01/02/2026"),
                        DataFim = DateTime.Now.AddDays(7),
                        KmInicial = veiculo2.Quilometragem,
                        KmFinal = veiculo2.Quilometragem + 5,
                        ValorDiaria = 100,
                        ValorTotal = 700
                    };


                    context.Locacoes.AddRange(locacao1, locacao2,locacao3,locacao4,locacao5,locacao6);

                    context.SaveChanges();
                }
            }
            app.Run();
        }
    }
}
