namespace tadbir.Service
{
    using System;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using tadbir.Repository;

    public abstract class BaseService
    {
        #region Fields
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;
        #endregion

        public BaseService(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

            ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            _logger = loggerFactory.CreateLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        }
    }
}