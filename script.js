/* =============================================================
   Alex Styles Portfolio — script.js
   Activity 3: Interactive UI/UX — Modal & Mobile Nav
   ============================================================= */

(function () {
  'use strict';

  /* ── Modal ──────────────────────────────────────────────── */
  const overlay   = document.getElementById('modal-overlay');
  const modalTitle = document.getElementById('modal-title');
  const modalBody  = document.getElementById('modal-body');
  const closeBtn   = document.getElementById('modal-close');
  const closeCta   = document.getElementById('modal-close-btn');

  function openModal(title, description) {
    modalTitle.textContent = title;
    modalBody.textContent  = description;
    overlay.classList.add('is-open');
    overlay.setAttribute('aria-hidden', 'false');
    closeBtn.focus();
    document.body.style.overflow = 'hidden';
  }

  function closeModal() {
    overlay.classList.remove('is-open');
    overlay.setAttribute('aria-hidden', 'true');
    document.body.style.overflow = '';
  }

  // Open modal on card click / Enter / Space
  document.querySelectorAll('.portfolio-card').forEach(function (card) {
    card.addEventListener('click', function () {
      openModal(card.dataset.title, card.dataset.description);
    });
    card.addEventListener('keydown', function (e) {
      if (e.key === 'Enter' || e.key === ' ') {
        e.preventDefault();
        openModal(card.dataset.title, card.dataset.description);
      }
    });
  });

  // Close via button
  closeBtn.addEventListener('click', closeModal);
  closeCta.addEventListener('click', closeModal);

  // Close via overlay click (outside modal box)
  overlay.addEventListener('click', function (e) {
    if (e.target === overlay) closeModal();
  });

  // Close via ESC key
  document.addEventListener('keydown', function (e) {
    if (e.key === 'Escape' && overlay.classList.contains('is-open')) {
      closeModal();
    }
  });

  /* ── Mobile Nav Toggle ──────────────────────────────────── */
  const navToggle = document.querySelector('.nav-toggle');
  const navList   = document.getElementById('nav-list');

  if (navToggle && navList) {
    navToggle.addEventListener('click', function () {
      const isOpen = navList.classList.toggle('is-open');
      navToggle.setAttribute('aria-expanded', String(isOpen));
    });

    // Close nav when a link is clicked (smooth scroll)
    navList.querySelectorAll('.nav-link').forEach(function (link) {
      link.addEventListener('click', function () {
        navList.classList.remove('is-open');
        navToggle.setAttribute('aria-expanded', 'false');
      });
    });
  }

  /* ── Contact Form (HTML5 validation feedback) ───────────── */
  const form = document.querySelector('.contact-form');
  if (form) {
    form.addEventListener('submit', function (e) {
      e.preventDefault();
      if (form.checkValidity()) {
        const btn = form.querySelector('.btn--primary');
        btn.textContent = 'Message Sent!';
        btn.disabled = true;
        btn.style.opacity = '0.7';
        form.reset();
        setTimeout(function () {
          btn.textContent = 'Send Message';
          btn.disabled = false;
          btn.style.opacity = '';
        }, 3000);
      }
    });
  }

})();
