using AutoFixture;
using AutoMapper;
using Jazani.Application.Generals.Dtos.Holders;
using Jazani.Application.Generals.Dtos.Holders.Profiles;
using Jazani.Application.Generals.Services;
using Jazani.Application.Generals.Services.Implementations;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Moq;

namespace Jazani.UnitTest.Application.Generals.Services
{
    public class HolderServiceTest
    {
        Mock<IHolderRepository> _mockHolderRepository;
        //Mock<Microsoft.Extensions.Logging.ILogger<HolderService>> _mockILogger;
        IMapper _mapper;
        Fixture _fixture;

        public HolderServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<HolderProfile>();
            });

            _fixture = new Fixture();
            _mapper = mapperConfiguration.CreateMapper();
            _mockHolderRepository = new Mock<IHolderRepository>();
            //_mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<HolderService>>();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            
        }
        [Fact]
        public async void returnHolderDtoWhenFindByIdAsync()
        {

            Holder holder = _fixture.Create<Holder>();

            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);

            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper);

            HolderDto holderDto = await holderService.FindByIdAsync(holder.Id);

            Assert.Equal(holder.Name, holderDto.Name);
        }

        [Fact]
        public async void returnHolderDtoWhenFindAllAsync()
        {
            //Arrage

            IReadOnlyList<Holder> holders = _fixture.CreateMany<Holder>(5).ToList();

            _mockHolderRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(holders);
            //Act
            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper);

            IReadOnlyList<HolderDto> holderDtos = await holderService.FindAllAsync();

            //Assert
            Assert.Equal(holders.Count, holderDtos.Count);
        }

    }
}
