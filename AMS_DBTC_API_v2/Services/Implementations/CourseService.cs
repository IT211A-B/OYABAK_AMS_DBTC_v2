using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Repository.Interface;
using AMS_DBTC_API_v2.Services.Interface;   

namespace AMS_DBTC_API_v2.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;
        public CourseService(ICourseRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<CourseDTO>> GetAllAsync()
        {
            var courses = await _repo.GetAllAsync();
            return courses.Select(c => new CourseDTO
            {
                CourseId = c.CourseId,
                Name = c.Name,
            });
        }
        public async Task<CourseDTO> GetCourseByIdAsync(int id)
        {
            var course = await _repo.GetByIdAsync(id);
            if (course == null)
                throw new KeyNotFoundException("Course not found");
            return new CourseDTO
            {
                CourseId = course.CourseId,
                Name = course.Name,
            };
        }

        public async Task<CourseDTO> CreateCourseAsync(CreateCourseDTO courseDto)
        {
            var course = new Models.Course
            {
                Name = courseDto.Name,
            };
            var createdCourse = await _repo.CreateAsync(course);
            return new CourseDTO
            {
                CourseId = createdCourse.CourseId,
                Name = createdCourse.Name,
            };
        }

        public async Task UpdateCourseAsync(int id, UpdateCourseDTO courseDto)
        {
            var course = await _repo.GetByIdAsync(id);
            if (course == null)
                throw new KeyNotFoundException("Course not found");
            course.Name = courseDto.Name;
            await _repo.UpdateAsync(course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _repo.GetByIdAsync(id);
            if (course == null)
                throw new KeyNotFoundException("Course not found");
            await _repo.DeleteAsync(course);
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByTeacherIdAsync(int teacherId)
        {
            var courses = await _repo.GetCoursesByTeacherIdAsync(teacherId);
            return courses.Select(c => new CourseDTO
            {
                CourseId = c.CourseId,
                Name = c.Name,
            });
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByStudentIdAsync(int studentId)
        {
            var courses = await _repo.GetCoursesByStudentIdAsync(studentId);
            return courses.Select(c => new CourseDTO
            {
                CourseId = c.CourseId,
                Name = c.Name,
            });
        }
    }
}
