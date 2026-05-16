import { useEffect } from "react";

function Faculty() {

    useEffect(() => {
        fetch("http://localhost:7167/api/faculty")
            .then(res => res.json())
            .then(data => {
                console.log("Faculty:", data);
            });
    }, []);

    return (
        <div>
            <h1>Faculty Page</h1>
        </div>
    );
}

export default Faculty;


function openAddModal() {
    document.getElementById('addModal').style.display = 'flex';
}

function openEditModal(empId, name, department, courses) {
    document.getElementById('editEmpId').value = empId;
    document.getElementById('editName').value = name;
    document.getElementById('editDepartment').value = department;
    document.getElementById('editCourses').value = courses;
    document.getElementById('editModal').style.display = 'flex';
}

function confirmDelete(empId, name) {
    document.getElementById('deleteEmpId').value = empId;
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
document.querySelectorAll('.faculty-select').forEach(function (sel) {
    sel.addEventListener('change', function () {
        this.closest('form').submit();
    });
});