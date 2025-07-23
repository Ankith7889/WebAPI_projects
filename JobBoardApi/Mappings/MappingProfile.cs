using AutoMapper;
using JobBoardApi.DTOs;
using JobBoardApi.Models;

namespace JobBoardApi.Mappings
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, CreateUserDto>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
            
            CreateMap<Job, JobDto>();
            CreateMap<CreateJobDto, Job>();

            CreateMap<JobApplication, JobApplicationDto>();
        }
    }
}
