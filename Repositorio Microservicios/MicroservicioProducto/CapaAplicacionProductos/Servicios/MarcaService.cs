using CapaDominioProductos.Comandos;
using CapaDominioProductos.DTOs;
using CapaDominioProductos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaAplicacionProductos.Servicios
{
    public interface IMarcaService
    {
        Marca createMarca(MarcaDto Marca);
    }
    public class MarcaService :IMarcaService
    {
        private readonly IGenericsRepository repository;

        public MarcaService(IGenericsRepository repository)
        {
            this.repository = repository;
        }

        public Marca createMarca(MarcaDto Marca)
        {
            var oMarca = new Marca()
            {
                Nombre = Marca.Nombre
            };
            repository.Agregar<Marca>(oMarca);
            return oMarca;
        }
    }
}
