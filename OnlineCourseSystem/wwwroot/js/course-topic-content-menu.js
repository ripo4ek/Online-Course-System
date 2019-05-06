$('.menu-content').on("click",
	function () {
		var taskId = $(this).data("id");
		for (let element in $('.task')) {
			if (taskId === element.data("taskId")) {
				continue;
			}
			element.hide();
		}
	});