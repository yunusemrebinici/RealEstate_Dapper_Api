
	//function openDeleteModal(id, cityName) {
	//	// Modal içindeki mesajı güncelle
	//	$("#deleteMessage").text(cityName + " adlı lokasyonu silmek istediğinize emin misiniz?");

	//// Silme butonunun URL'sini güncelle
	//$("#confirmDeleteBtn").attr("href", "/PopularLocation/DeletePopularLocation/" + id);

	//// Modalı aç
	//$("#deleteModal").modal("show");
	//}

	//// Modal kapatma işlemi
	//$(document).ready(function () {
	//	$("#deleteModal .close, #deleteModal .btn-secondary").on("click", function () {
	//		$("#deleteModal").modal("hide");
	//	});
	//});

function openModal(modalId, message, confirmUrl) {
    let modal = document.querySelector(`#${modalId}`);
    if (!modal) {
        console.error("Modal bulunamadı:", modalId);
        return;
    }

    // Mesajı güncelle
    let messageElement = modal.querySelector(".modal-body p");
    if (messageElement) {
        messageElement.innerText = message;
    } else {
        console.error("Mesaj alanı bulunamadı");
    }

    // Silme butonunun URL'sini güncelle
    let confirmButton = modal.querySelector("#confirmButton");
    if (confirmButton) {
        confirmButton.href = confirmUrl;
    } else {
        console.error("Confirm butonu bulunamadı");
    }

    // Modalı aç
    $(`#${modalId}`).modal("show");

    // Modal kapama işlemleri
    $(".btn-close, .btn-secondary").on("click", function () {
        $(`#${modalId}`).modal("hide");
    });
}
