using AutoFixture;
using AutoMapper;
using Jazani.Application.Generals.Dtos.Holders.Profiles;
using Jazani.Application.Generals.Dtos.InvestmentConcepts.Profiles;
using Jazani.Application.Generals.Dtos.Investments.Profiles;
using Jazani.Application.Generals.Dtos.InvestmentTypes.Profiles;
using Jazani.Application.Generals.Dtos.MeasureUnits.Profiles;
using Jazani.Application.Generals.Dtos.MiningConcessions.Profiles;
using Jazani.Application.Generals.Dtos.PeriodTypes;
using Jazani.Application.Generals.Dtos.PeriodTypes.Profiles;
using Jazani.Application.Generals.Services;
using Jazani.Application.Generals.Services.Implementations;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Moq;

namespace Jazani.UnitTest.Application.Generals.Services
{
    public class PeriodTypeServiceTest
    {
        Mock<IPeriodTypeRepository> _mockPeriodTypeRepository;
        //Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>> _mockIlogger;
        Fixture _fixture;
        IMapper _mapper;
        public PeriodTypeServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<PeriodTypeProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();
            _mockPeriodTypeRepository = new Mock<IPeriodTypeRepository>();
           // _mockIlogger = new Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>>();
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async void returnPeriodTypeDtoWhenFindByAsync()
        {
            // Arrange

            PeriodType periodType = _fixture.Create<PeriodType>();

            _mockPeriodTypeRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(periodType);

            // Act
            IPeriodTypeService periodTypeService = new PeriodTypeService(_mockPeriodTypeRepository.Object, _mapper);

            PeriodTypeDto periodTypeDto = await periodTypeService.FindByIdAsync(periodType.Id);

            //Assert
            Assert.Equal(periodType.Name, periodType.Name);

        }
        [Fact]
        public async void returnPeriodTypeDtoWhenFindAllAsync()
        {
            // Arrange

            IReadOnlyList<PeriodType> periodTypes = _fixture.CreateMany<PeriodType>(100).ToList();

            _mockPeriodTypeRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(periodTypes);

            // Act
            IPeriodTypeService periodTypeService = new PeriodTypeService(_mockPeriodTypeRepository.Object, _mapper);

            IReadOnlyList<PeriodTypeDto> periodTypeDtos = await periodTypeService.FindAllAsync();

            //Assert
            Assert.Equal(periodTypes.Count, periodTypeDtos.Count);

        }
        [Fact]
        public async void returnPeriodTypeDtoWhenCreateAsync()
        {

            // Arrange
            int id = 1;
            PeriodType periodType = new()
            {
                Id = id,
                Name = "Anual",
                Description = "description01",
                Time = 2,
                RegistrationDate = DateTime.Now,
                State = true
                
            };
            _mockPeriodTypeRepository
               .Setup(r => r.SaveAsync(It.IsAny<PeriodType>()))
               .ReturnsAsync(periodType);

            // Act
            PeriodTypeSaveDto periodTypeSaveDto = new()
            {
                Name = periodType.Name,
                Description = periodType.Description,
                Time = periodType.Time
            };

            IPeriodTypeService periodTypeService = new PeriodTypeService(_mockPeriodTypeRepository.Object, _mapper);

            PeriodTypeDto periodTypeDto = await periodTypeService.CreateAsync(periodTypeSaveDto);

            //Assert
            Assert.Equal(periodType.Name, periodTypeDto.Name);

        }
        [Fact]
        public async void returnPeriodTypeDtoWhenEditAsync()
        {
            // Arrange
            int id = 1;
            PeriodType periodType = new()
            {
                Id = id,
                Name = "Anual",
                Description = "description01",
                Time = 2,
                RegistrationDate = DateTime.Now,
                State = true

            };
            _mockPeriodTypeRepository
               .Setup(r => r.SaveAsync(It.IsAny<PeriodType>()))
               .ReturnsAsync(periodType);

            _mockPeriodTypeRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(periodType);

            // Act
            PeriodTypeSaveDto periodTypeSaveDto = new()
            {
                Name = periodType.Name,
                Description = periodType.Description,
                Time = periodType.Time
            };

            IPeriodTypeService periodTypeService = new PeriodTypeService(_mockPeriodTypeRepository.Object, _mapper);

            PeriodTypeDto periodTypeDto = await periodTypeService.EditAsync(id,periodTypeSaveDto);

            //Assert
            Assert.Equal(periodType.Name, periodTypeDto.Name);

        }
        [Fact]
        public async void returnPeriodTypeDtoWhenDisableAsync()
        {
            // Arrange
            int id = 1;
            PeriodType periodType = new()
            {
                Id = id,
                Name = "Anual",
                Description = "description01",
                Time = 2,
                RegistrationDate = DateTime.Now,
                State = false

            };
            _mockPeriodTypeRepository
              .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
              .ReturnsAsync(periodType);

            _mockPeriodTypeRepository
               .Setup(r => r.SaveAsync(It.IsAny<PeriodType>()))
               .ReturnsAsync(periodType);

            // Act
            PeriodTypeSaveDto periodTypeSaveDto = new()
            {
                Name = periodType.Name,
                Description = periodType.Description,
                Time = periodType.Time
            };

            IPeriodTypeService periodTypeService = new PeriodTypeService(_mockPeriodTypeRepository.Object, _mapper);

            PeriodTypeDto periodTypeDto = await periodTypeService.DisabledAsync(id);

            //Assert
            Assert.Equal(periodType.Name, periodTypeDto.Name);

        }
    
    
    }
}
