using AutoMapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class BaseService<TBLLEntity, TDLLEntity>: IDisposable where TBLLEntity:class
    {
        public IUnitOfWork UnitOfWork { get; protected set; }

        private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TDLLEntity, TBLLEntity>();
            cfg.CreateMap<TBLLEntity, TDLLEntity>();
        }).CreateMapper();
        private bool disposedValue;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public static TDLLEntity ToDalEntity(TBLLEntity bllEntity)
        {
            return _mapper.Map<TBLLEntity, TDLLEntity>(bllEntity);
        }

        public static IEnumerable<TDLLEntity> ToDalEntity(IEnumerable<TBLLEntity> bllEntity)
        {
            return _mapper.Map<IEnumerable<TBLLEntity>, List<TDLLEntity>>(bllEntity);
        }

        public static TBLLEntity ToBllEntity(TDLLEntity dalEntity)
        {
            return _mapper.Map<TDLLEntity, TBLLEntity>(dalEntity);
        }

        public static IEnumerable<TBLLEntity> ToBllEntity(IEnumerable<TDLLEntity> dalEntity)
        {
            return _mapper.Map<IEnumerable<TDLLEntity>, List<TBLLEntity>>(dalEntity);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты)
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~BaseService()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
