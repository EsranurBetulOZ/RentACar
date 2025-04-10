using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Colors;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Mappers.Brands;
using Arac_Kiralama.Service.Mappers.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Concretes
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IColorMapper _colorMapper;

        public ColorService(IColorRepository colorRepository, IColorMapper colorMapper)
        {
            _colorRepository = colorRepository;
            _colorMapper = colorMapper;
        }

        public void Add(ColorAddRequestDto dto)
        {
            Color color = _colorMapper.ConvertToEntity(dto);
            _colorRepository.Add(color);
        }

        public void Delete(int id)
        {
            Color? color = _colorRepository.GetById(id);
            //toDo: Eğer ilgili color bulunamazsa exeption Handling mekanizması 
            _colorRepository.Delete(color!);
        }

        public List<ColorResponseDto> GetAll()
        {
            List<Color> colors = _colorRepository.GetAll();
            List<ColorResponseDto> responses = _colorMapper.ConvertToResponseList(colors);
            return responses;
        }

        public ColorResponseDto GetById(int id)
        {
            Color? color = _colorRepository.GetById(id);
            //toDo: Eğer ilgili color bulunamazsa exeption Handling mekanizması 
            ColorResponseDto dto = _colorMapper.ConvertToResponse(color!);
            return dto;
        }

        public void Update(ColorUpdateRequestDto dto)
        {
            Color color = _colorMapper.ConvertToEntity(dto);
            _colorRepository.Update(color);
        }
    }
}
