using System;
using CoreProject.Core.Entity;
using CoreProject.Core.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CoreProject.Presentation
{
    public class Application : IApplication
    {
        #region Properties and Constructors
        public IServiceProvider Services { get; set; }
        public IClienteRepository ClienteRepository { get; set; }

        public Application(IServiceProvider _services)
        {
            Services = _services;
            Run();
        }
        #endregion

        #region Methods
        public void Run()
        {
            ClienteRepository = Services.GetRequiredService<IClienteRepository>();
            ClienteRepository.Insert(new Cliente
            {
                ClienteId = Guid.NewGuid(),
                Nome = "Teste",
                Cpf = "01234567890",
                Telefone = "31998765432",
                DataCadastro = DateTime.Now
            });
        }
        #endregion
    }
}
