import { useEffect, useState } from "react";

function Course() {
    const [courses, setCourses] = useState([]);

    useEffect(() => {
        fetch("http://localhost:7167/api/course")
            .then((res) => res.json())
            .then((data) => {
                setCourses(data);
                console.log("Courses:", data);
            })
            .catch((err) => {
                console.error("Error fetching courses:", err);
            });
    }, []);

    return (
        <div>
            <h1>Course Page</h1>

            <ul>
                {courses.map((course, index) => (
                    <li key={index}>
                        {JSON.stringify(course)}
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default Course;

function openAddModal() {
    document.getElementById('addModal').style.display = 'flex';
}

function openEditModal(code, name, faculty, semester) {
    document.getElementById('editCode').value = code;
    document.getElementById('editName').value = name;
    document.getElementById('editFaculty').value = faculty;
    document.getElementById('editSemester').value = semester;
    document.getElementById('editModal').style.display = 'flex';
}

function confirmDelete(code, name) {
    document.getElementById('deleteCode').value = code;
    document.getElementById('deleteMessage').textContent = 'Are you sure you want to delete ' + name + '? This action cannot be undone.';
    document.getElementById('deleteModal').style.display = 'flex';
}

function closeModal(modalId) {
    document.getElementById(modalId).style.display = 'none';
}

// close modal if user clicks outside the box
document.querySelectorAll('.modal-overlay').forEach(function (overlay) {
    overlay.addEventListener('click', function (e) {
        if (e.target === overlay) {
            overlay.style.display = 'none';
        }
    });
});

// auto submit filter form on select change
document.querySelectorAll('.course-select').forEach(function (sel) {
    sel.addEventListener('change', function () {
        this.closest('form').submit();
    });
});