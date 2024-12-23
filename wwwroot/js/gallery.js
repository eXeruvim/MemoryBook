document.addEventListener("DOMContentLoaded", () => {
  const modalImage = document.getElementById("modalImage");
  const modalDescription = document.getElementById("modalDescription");
  const galleryModal = new bootstrap.Modal(
    document.getElementById("galleryModal")
  );

  document.querySelectorAll(".gallery-image").forEach((img) => {
    img.addEventListener("click", function () {
      const imageUrl = this.getAttribute("data-bs-image");
      const description = this.getAttribute("data-bs-description");
      modalImage.src = imageUrl;
      modalDescription.textContent = description;

      // Показ модального окна
      galleryModal.show();
    });
  });
});
