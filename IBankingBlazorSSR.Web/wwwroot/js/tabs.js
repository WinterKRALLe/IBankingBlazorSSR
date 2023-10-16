// function initializeTabs() {
//     let tabs = document.querySelectorAll(".tab");
//     let indicator = document.querySelector(".indicator");
//     let panels = document.querySelectorAll(".tab-panel");
//
//     indicator.style.width = tabs[0].getBoundingClientRect().width + 'px';
//     indicator.style.left = tabs[0].getBoundingClientRect().left - tabs[0].parentElement.getBoundingClientRect().left + 'px';
//
//     tabs.forEach(tab => {
//         tab.addEventListener("click", () => {
//             let tabTarget = tab.getAttribute("aria-controls");
//
//             indicator.style.width = tab.getBoundingClientRect().width + 'px';
//             indicator.style.left = tab.getBoundingClientRect().left - tab.parentElement.getBoundingClientRect().left + 'px';
//
//             panels.forEach(panel => {
//                 let panelId = panel.getAttribute("id");
//                 if (tabTarget === panelId) {
//                     panel.classList.remove("invisible", "opacity-0");
//                     panel.classList.add("visible", "opacity-100");
//                 } else {
//                     panel.classList.add("invisible", "opacity-0");
//                 }
//             });
//         });
//     });
// }

window.initializeTabs = function() {
    let tabs = document.querySelectorAll(".tab");
    let indicator = document.querySelector(".indicator");
    let panels = document.querySelectorAll(".tab-panel");

    indicator.style.width = tabs[0].getBoundingClientRect().width + 'px';
    indicator.style.left = tabs[0].getBoundingClientRect().left - tabs[0].parentElement.getBoundingClientRect().left + 'px';

    tabs.forEach(tab => {
        tab.addEventListener("click", () => {
            tabs.forEach(otherTab => {
                if (otherTab === tab) {
                    otherTab.classList.remove("text-skin-base2");
                    otherTab.classList.add("text-skin-base");
                } else {
                    otherTab.classList.remove("text-skin-base");
                    otherTab.classList.add("text-skin-base2");
                }
            });

            let tabTarget = tab.getAttribute("aria-controls");

            indicator.style.width = tab.getBoundingClientRect().width + 'px';
            indicator.style.left = tab.getBoundingClientRect().left - tab.parentElement.getBoundingClientRect().left + 'px';

            panels.forEach(panel => {
                let panelId = panel.getAttribute("id");
                if (tabTarget === panelId) {
                    panel.classList.remove("invisible", "opacity-0");
                    panel.classList.add("visible", "opacity-100");
                } else {
                    panel.classList.add("invisible", "opacity-0");
                }
            });
        });
    });
};