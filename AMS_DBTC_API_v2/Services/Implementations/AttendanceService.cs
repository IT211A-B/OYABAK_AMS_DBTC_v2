using AMS_DBTC_API_v2.Services.Interface;
using AMS_DBTC_API_v2.Repository.Interface;
using AMS_DBTC_API_v2.DTOs;
using AMS_DBTC_API_v2.Models;

namespace AMS_DBTC_API_v2.Services.Implementations
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ICourseRepository _courseRepository;
        public AttendanceService(IAttendanceRepository attendanceRepository, ICourseRepository courseRepository)
        {
            _attendanceRepository = attendanceRepository;
            _courseRepository = courseRepository;
        }
        public async Task<AttendanceDTO> CreateAttendanceAsync(AttendanceUpsertDTO attendanceDto)
        {
            var course = await _courseRepository.GetByIdAsync(attendanceDto.CourseId);
            if (course == null)
            {
                throw new Exception("Course not found");
            }
            var attendance = new Attendance
            {
                StudentId = attendanceDto.StudentId,
                CourseId = attendanceDto.CourseId,
                Date = attendanceDto.Date,
                Status = attendanceDto.Status
            };
            var createdAttendance = await _attendanceRepository.CreateAsync(attendance);
            return new AttendanceDTO
            {
                AttendanceId = createdAttendance.AttendanceId,
                StudentId = createdAttendance.StudentId,
                CourseId = createdAttendance.CourseId,
                Date = createdAttendance.Date,
                Status = createdAttendance.Status
            };
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAllAsync()
        {
            var attendances = await _attendanceRepository.GetAllAsync();
            return attendances.Select(a => new AttendanceDTO
            {
                AttendanceId = a.AttendanceId,
                StudentId = a.StudentId,
                CourseId = a.CourseId,
                Date = a.Date,
                Status = a.Status
            });
        }

        public async Task<AttendanceDTO> GetAttendanceByIdAsync(int id)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(id);
            if (attendance == null)
                throw new KeyNotFoundException("Attendance record not found");
            return new AttendanceDTO
            {
                AttendanceId = attendance.AttendanceId,
                StudentId = attendance.StudentId,
                CourseId = attendance.CourseId,
                Date = attendance.Date,
                Status = attendance.Status
            };
        }

        public async Task<bool> UpdateAttendanceAsync(int id, AttendanceUpsertDTO attendanceDto)
        {
            var existing = await _attendanceRepository.GetByIdAsync(id);
            if (existing == null)
                return false;
            existing.StudentId = attendanceDto.StudentId;
            existing.CourseId = attendanceDto.CourseId;
            existing.Date = attendanceDto.Date;
            existing.Status = attendanceDto.Status;
            var updatedAttendance = await _attendanceRepository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var existing = await _attendanceRepository.GetByIdAsync(id);
            if (existing == null) 
            {  
                return false; 
            }
         
            await _attendanceRepository.DeleteAsync(existing.AttendanceId);
            return true;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesByCourseIdAsync(int courseId)
        {
            var attendances = await _attendanceRepository.GetAttendancesByCourseIdAsync(courseId);
            return attendances.Select(a => new AttendanceDTO
            {
                AttendanceId = a.AttendanceId,
                StudentId = a.StudentId,
                CourseId = a.CourseId,
                Date = a.Date,
                Status = a.Status
            });
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesByStudentIdAsync(int studentId)
        {
            var attendances = await _attendanceRepository.GetAttendancesByStudentIdAsync(studentId);
            return attendances.Select(a => new AttendanceDTO
            {
                AttendanceId = a.AttendanceId,
                StudentId = a.StudentId,
                CourseId = a.CourseId,
                Date = a.Date,
                Status = a.Status
            });
        }
    }
}
