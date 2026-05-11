// Kütüphane Otomasyon Sistemi - Site JavaScript

// Hero bölümü scroll ile soluklaşma efekti
document.addEventListener('DOMContentLoaded', function () {

    var heroBolum = document.querySelector('.hero-bolum');

    // Hero bölümü yoksa (ana sayfa dışında) işlem yapma
    if (!heroBolum) return;

    var heroYuksekligi = heroBolum.offsetHeight;

    window.addEventListener('scroll', function () {
        var scrollY = window.scrollY || window.pageYOffset;

        // Opaklık hesapla: scrollY=0 → opaklık=1.0, scrollY=heroYuksekligi → opaklık=0.30
        var minOpaklık = 0.30;
        var opaklık = 1 - (scrollY / heroYuksekligi) * (1 - minOpaklık);

        // Sınırla
        if (opaklık < minOpaklık) opaklık = minOpaklık;
        if (opaklık > 1)          opaklık = 1;

        heroBolum.style.opacity = opaklık;
    });

});
