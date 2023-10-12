using AutoFixture;
using AutoMapper;
using Jazani.Application.Generals.Dtos.Holders.Profiles;
using Jazani.Application.Generals.Dtos.InvestmentConcepts.Profiles;
using Jazani.Application.Generals.Dtos.Investments;
using Jazani.Application.Generals.Dtos.Investments.Profiles;
using Jazani.Application.Generals.Dtos.InvestmentTypes.Profiles;
using Jazani.Application.Generals.Dtos.MeasureUnits.Profiles;
using Jazani.Application.Generals.Dtos.MiningConcessions.Profiles;
using Jazani.Application.Generals.Dtos.PeriodTypes.Profiles;
using Jazani.Application.Generals.Services;
using Jazani.Application.Generals.Services.Implementations;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Moq;

namespace Jazani.UnitTest.Application.Generals.Services
{
    public class InvestmentServiceTest
    {
        Mock<IInvestmentRepository> _mockInvestmentRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>> _mockIlogger;
        Fixture _fixture;
        IMapper _mapper;

        public InvestmentServiceTest()
        {
          MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmentProfile>();
                c.AddProfile<HolderProfile>();
                c.AddProfile<InvestmentConceptProfile>();
                c.AddProfile<InvestmentTypeProfile>();
                c.AddProfile<MiningConcessionProfile>();
                c.AddProfile<PeriodTypeProfile>();
                c.AddProfile<MeasureUnitProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();
            _mockInvestmentRepository = new Mock<IInvestmentRepository>();
            _mockIlogger = new Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>>();
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async void returnInvestmentDtoWhenFindByAsync()
        {
            // Arrange
            Investment investment = _fixture.Create<Investment>();

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            // Act
            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockIlogger.Object);
            InvestmentDto investmentDto = await investmentService.FindByIdAsync(investment.Id);

            //Assert
            Assert.Equal(investment.Id, investment.Id);

        }

        [Fact]
        public async void returnInvestmentDtoWhenFindAllAsync()
        {
            // Arrange

            IReadOnlyList<Investment> investments = _fixture.CreateMany<Investment>(5).ToList();

            _mockInvestmentRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(investments);

            // Act
            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockIlogger.Object);
            IReadOnlyList<InvestmentDto> investmentDtos = await investmentService.FindAllAsync();

            //Assert
            Assert.Equal(investments.Count, investmentDtos.Count);

        }
        
        [Fact]
        public async void returnInvestmentDtoWhenCreateAsync()
        {
            // Arrange
            int id = 120;
            Investment investment = new()
            {
               
               Id = id,
               AmountInvestd = 10,
               Description = "Vamos",
               HolderId =4,
               InvestmentConceptId =2,
               InvestmentTypeId =1,
               CurrencyTypeId = 2,
               MiningConcessionId =29,
               MeasureUnitId = null,
               PeriodTypeId =  null,
               RegistrationDate = DateTime.Now,
               State = true,
               MonthName =  "Abril",
               DeclaredTypeId = 0,
               DocumentId =  null
             };

            _mockInvestmentRepository
               .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
               .ReturnsAsync(investment);


            // Act
            InvestmentSaveDto investmentSaveDto = new()
            {
                AmountInvestd = investment.AmountInvestd,
                Description = investment.Description,
                HolderId = investment.HolderId,
                InvestmentConceptId = investment.InvestmentConceptId,
                InvestmentTypeId = investment.InvestmentTypeId,
                CurrencyTypeId = investment.CurrencyTypeId,
                MiningConcessionId = investment.MiningConcessionId,
                MeasureUnitId = investment.MeasureUnitId,
                PeriodTypeId = investment.PeriodTypeId,
                MonthName = investment.MonthName,
                DeclaredTypeId = investment.DeclaredTypeId,
                DocumentId = investment.DocumentId
            };

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockIlogger.Object);

            InvestmentDto investmentDto = await investmentService.CreateAsync(investmentSaveDto);

            //Assert
            Assert.Equal(investment.Description, investmentDto.Description);

        }
       
        [Fact]
        public async void returnInvestmentDtoWhenEditAsync()
        {
            // Arrange
            int id = 120;
            Investment investment = new()
            {

                Id = id,
                AmountInvestd = 10,
                Description = "Vamos",
                HolderId = 4,
                InvestmentConceptId = 2,
                InvestmentTypeId = 1,
                CurrencyTypeId = 2,
                MiningConcessionId = 29,
                MeasureUnitId = null,
                PeriodTypeId = null,
                RegistrationDate = DateTime.Now,
                State = true,
                MonthName = "Abril",
                DeclaredTypeId = 0,
                DocumentId = null
            };

            _mockInvestmentRepository
               .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
               .ReturnsAsync(investment);

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            // Act
            InvestmentSaveDto investmentSaveDto = new()
            {
                AmountInvestd = investment.AmountInvestd,
                Description = investment.Description,
                HolderId = investment.HolderId,
                InvestmentConceptId = investment.InvestmentConceptId,
                InvestmentTypeId = investment.InvestmentTypeId,
                CurrencyTypeId = investment.CurrencyTypeId,
                MiningConcessionId = investment.MiningConcessionId,
                MeasureUnitId = investment.MeasureUnitId,
                PeriodTypeId = investment.PeriodTypeId,
                MonthName = investment.MonthName,
                DeclaredTypeId = investment.DeclaredTypeId,
                DocumentId = investment.DocumentId
            };

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockIlogger.Object);
            InvestmentDto investmentDto = await investmentService.EditAsync(id ,investmentSaveDto);

            //Assert
            Assert.Equal(investment.Description, investmentDto.Description);

        }

        [Fact]
        public async void returnInvestmentDtoWhenDisableAsync()
        {
            // Arrange
            int id = 120;
            Investment investment = new()
            {

                Id = id,
                AmountInvestd = 10,
                Description = "Vamos",
                HolderId = 4,
                InvestmentConceptId = 2,
                InvestmentTypeId = 1,
                CurrencyTypeId = 2,
                MiningConcessionId = 29,
                MeasureUnitId = null,
                PeriodTypeId = null,
                RegistrationDate = DateTime.Now,
                State = false,
                MonthName = "Abril",
                DeclaredTypeId = 0,
                DocumentId = null
            };
            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mockInvestmentRepository
               .Setup(r => r.SaveAsync(It.IsAny<Investment>()));


            // Act
            InvestmentSaveDto investmentSaveDto = new()
            {
                AmountInvestd = investment.AmountInvestd,
                Description = investment.Description,
                HolderId = investment.HolderId,
                InvestmentConceptId = investment.InvestmentConceptId,
                InvestmentTypeId = investment.InvestmentTypeId,
                CurrencyTypeId = investment.CurrencyTypeId,
                MiningConcessionId = investment.MiningConcessionId,
                MeasureUnitId = investment.MeasureUnitId,
                PeriodTypeId = investment.PeriodTypeId,
                MonthName = investment.MonthName,
                DeclaredTypeId = investment.DeclaredTypeId,
                DocumentId = investment.DocumentId
            };
            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockIlogger.Object);
            InvestmentDto investmentDto = await investmentService.DisabledAsync(id);

            //Assert
            Assert.Equal(investment.State, investmentDto.State);

        }
    }
}
