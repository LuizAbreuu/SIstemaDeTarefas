using Microsoft.EntityFrameworkCore;
using Refit;
using SIstemaDeTarefas.Data;
using SIstemaDeTarefas.integracao;
using SIstemaDeTarefas.integracao.interfaces;
using SIstemaDeTarefas.integracao.Refit;
using SIstemaDeTarefas.Repositorios;
using SIstemaDeTarefas.Repositorios.interfaces;

namespace SIstemaDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemasTarefasDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
            builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();

            builder.Services.AddRefitClient<IViaCepintegracaoRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
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

            app.Run();
        }
    }
}