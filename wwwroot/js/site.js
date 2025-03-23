// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<script>
    document.addEventListener("DOMContentLoaded", function () {
        const carouselTrack = document.querySelector(".carousel-track");
    const carCards = [
    {
        image: "https://prod.cosy.bmw.cloud/bmwweb/cosySec?COSY-EU-100-7331rjFhnOqIbqcTZ%25L3hpvYLfCny2oWYgpnQ97lX80UrOohZkVAfS5cVLNHCLvhJP%25z6eEzFu4fXBjvWzmQltE6BmudhSId4k9VTCrmpIUrOrJrhDGwXHi4T4qF9%25rJHFlFe6ou4TJIsIUzL3FlTv0VliyXIslGAzWECrv0s9OaRBE4GA0ogRwlNF9OALUxnXkIogOybW5KnvLUgChe2B5GybUEqjpx89ChbNmQtiPoEqhk7ZnHMLNmqn1cmaDyk7m5VKGPYCn178zB3vtE5V1Pa28mfN8zVMRpoMSkPazDxTKAdnMRaYWlALQ5DxRtesOwZ8YWxfj0gKcPteWS6AdaKMfjedwOQNBDS6jQ%25gZp2Ydw6ZuUNfptQ%25wc3bnFifZu%25KXh5JHSc3uBrq9YJdKX324mIKTQBrXpF7CAlZ24riI15ascpF4HvVAA0KiIFJGz7xABHvIT9a1nO2JGvloILUgpT9GsLvS6Uilo90yG10bHsLoAC9VshJ0yLOEozxqTACygNLpfmlOECUkaKH7sgNEbnR2V10UkNh5xWqVAbnkq8WeszOh5nmPej4agq857MjK0RUmP81D6psxb7MPVYws5Wh1DMzt%25r0eqVYDafu46jmztYRSaLP67aftxdRyww1RSfWQxDD%25VxdSeZWCuuzWQdjceTE3aeZQ6KjPpXRjcZwBZvHrx6Kc%252cqJ4WwBKupK5jFe%252B3iBucIjup2XH2fwv63iprJp9eGwXHi4TfF99%25UHNMClix2t5JUABNItPb9FSrTLn9lVc%25s6l89RpC0vQFju1dWS2aOIXRTVcwL9cvtT7672yzH3OYgMTN6uQmlDTI0Ccy2of4Y",
    name: "BMW X5",
    price: "$120/day",
    link: "/Car/Detail/1"
            },
    {
        image: "https://kong-proxy-intranet.toyota-europe.com/c1-images/resize/ccis/680x680/zip/bg/product-token/0c77ac68-d19e-4c1b-b714-b48f1d0a803b/vehicle/ba27962c-39a3-471d-a59b-9ba1938ea8eb/padding/50,50,50,50/image-quality/70/day-exterior-04_4y6.png",
    name: "Toyota Camry",
    price: "$50/day",
    link: "/Car/Detail/2"
            },
    {
        image: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQle7rOjsAdhTfpggSwLzKnflAShadVzCWb7Q&s",
    name: "Ford Transit",
    price: "$60/day",
    link: "/Car/Detail/3"
            },
    {
        image: "https://platform.cstatic-images.com/in/v2/stock_photos/c4359896-c20e-46da-87a2-a7b2734561b3/c0535e58-31b9-488d-b5b7-55818402e3e6.png",
    name: "Audi A4",
    price: "$120/day",
    link: "/Car/Detail/4"
            }
    ];

    // Function to create a car card
    function createCarCard(car) {
            return `
    <div class="car-card">
        <img src="${car.image}" alt="${car.name}">
            <h3>${car.name}</h3>
            <p>${car.price}</p>
            <a href="${car.link}" class="btn btn-primary">Rent Now</a>
    </div>
    `;
        }

    // Duplicate the car cards to create an infinite loop
    const carouselContent = carCards.map(createCarCard).join("");
    carouselTrack.innerHTML = carouselContent + carouselContent; // Duplicate content
    });
</script>
const prevButton = document.querySelector(".carousel-prev");
const nextButton = document.querySelector(".carousel-next");

prevButton.addEventListener("click", () => {
    carouselTrack.style.transform = "translateX(-50%)";
});

nextButton.addEventListener("click", () => {
    carouselTrack.style.transform = "translateX(0)";
});