import { useEffect } from "react";

function Attendance() {

    useEffect(() => {
        fetch("http://localhost:7167/api/attendance")
            .then(res => res.json())
            .then(data => {
                console.log("Attendance:", data);
            });
    }, []);

    return (
        <div>
            <h1>Attendance Page</h1>
        </div>
    );
}

export default Attendance;


//document.querySelectorAll('.attendance-select').forEach(function (sel) {
//    sel.addEventListener('change', function () {
//        this.closest('form').submit();
//    });
//});

document.querySelectorAll('.attendance-select, #studentNameSearch').forEach(el => {
    el.addEventListener('keydown', e => {
        if (e.key === 'Enter') e.preventDefault(); // prevent form submit on enter huhuness
    });
});