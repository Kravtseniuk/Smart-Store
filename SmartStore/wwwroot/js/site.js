document.addEventListener("DOMContentLoaded", function () {
	const sidebar = document.getElementById("adminSidebar");
	const toggleBtn = document.getElementById("sidebarToggle");

	const overlay = document.createElement("div");
	overlay.classList.add("sidebar-overlay");
	document.body.appendChild(overlay);

	if (localStorage.getItem("sidebarOpen") === "true") {
		sidebar.classList.add("open");
		overlay.classList.add("active");
	}

	toggleBtn?.addEventListener("click", function (e) {
		e.stopPropagation();
		sidebar.classList.toggle("open");
		overlay.classList.toggle("active");
		localStorage.setItem("sidebarOpen", sidebar.classList.contains("open"));
	});

	overlay.addEventListener("click", function () {
		sidebar.classList.remove("open");
		overlay.classList.remove("active");
		localStorage.setItem("sidebarOpen", "false");
	});

	sidebar.querySelectorAll(".sidebar-nav a").forEach(link => {
		link.addEventListener("click", function () {
			sidebar.classList.remove("open");
			overlay.classList.remove("active");
			localStorage.setItem("sidebarOpen", "false");
		});
	});
});