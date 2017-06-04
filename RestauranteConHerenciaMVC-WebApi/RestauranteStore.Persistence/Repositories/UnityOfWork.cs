using RestauranteStore.Entities.IRepositories;
using RestauranteStore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly RestauranteStoreDbContext _Context;

        public IAlmacenRepository Almacenes { get; private set; }
        public ICancelarReservaRepository CancelarReservas { get; private set; }
        public ICartaRepository Cartas { get; private set; }
        public IClienteRepository Clientes { get; private set; }
        public IEmpleadoRepository Empleados { get; private set; }
        public IEspecialidadDiaRepository EspecialidadDias { get; private set; }
        public IEstadoPedidoRepository EstadoPedidos { get; private set; }
        public IIngredienteRepository Ingredientes { get; private set; }
        public IMesaRepository Mesas { get; private set; }
        public IPedidoRepository Pedidos { get; private set; }
        public IPersonaRepository Personas { get; private set; }
        public IPlatoComidaRepository PlatoComidas { get; private set; }
        public IProveedorRepository Proveedors { get; private set; }
        public IReservaRepository Reservas { get; private set; }
        public ITipoEmpleadoRepository TipoEmpleados { get; private set; }
        public ITurnoRepository Turnos { get; private set; }

        public UnityOfWork()
        {

        }

        public UnityOfWork(RestauranteStoreDbContext context)
        {
            _Context = context;

            Almacenes = new AlmacenRepository(_Context);
            CancelarReservas = new CancelarReservaRepository(_Context);
            Cartas = new CartaRepository(_Context);
            EspecialidadDias = new EspecialidadDiaRepository(_Context);
            EstadoPedidos = new EstadoPedidoRepository(_Context);
            Ingredientes = new IngredienteRepository(_Context);
            Mesas = new MesaRepository(_Context);
            Pedidos = new PedidoRepository(_Context);
            Personas = new PersonaRepository(_Context);
            PlatoComidas = new PlatoComidaRepository(_Context);
            Reservas = new ReservaRepository(_Context);
            TipoEmpleados = new TipoEmpleadoRepository(_Context);
            Turnos = new TurnoRepository(_Context);
        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public void StateModedified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
