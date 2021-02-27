using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cities : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;
        public Cities(IAppRepository appRepository, IMapper Mapper)
        {
            _appRepository = appRepository;
            _mapper = Mapper;
        }

        public ActionResult GetCities()
        {
            var cities = _appRepository.GetCities();
            var ctiesreturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(ctiesreturn);
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add([FromBody]City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();
            return Ok(city);
        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetCityById(int id)
        {
            var city = _appRepository.GetCityById(id);
            var cityreturn = _mapper.Map<CityForDetailDto>(city);
            return Ok(cityreturn);
        }

        [HttpGet]
        [Route("photos")]
        public ActionResult GetPhotoByCity(int id)
        {
            var photo = _appRepository.GetPhotosByCity(id);
            return Ok(photo);
        }
    }
}
