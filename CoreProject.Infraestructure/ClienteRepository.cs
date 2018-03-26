using CoreProject.Core.Entity;
using CoreProject.Core.Interface;

namespace CoreProject.Infraestructure
{
    public class ClienteRepository : IClienteRepository
    {
        public CoreContext contexto;

        public ClienteRepository(CoreContext _contexto)
        {
            contexto = _contexto;
        }

        public void Insert(Cliente cliente)
        {
            using (contexto)
            {
                contexto.Clientes.Add(cliente);
                contexto.SaveChanges();
            }
        }
    }
}
