# Alex Styles — Graphic Designer Portfolio

A responsive, interactive portfolio website built for the **Microsoft Front End Developer** course (UI/UX Design Principles). This project is completed in three activities, each building on the last.

**Live site:** https://jdsaire.github.io/portfolio

---

## Project Structure

```
├── index.html    — Full HTML structure (nav, about, portfolio, contact)
├── styles.css    — All CSS across Activities 1–3
├── script.js     — JavaScript for modals, mobile nav, form feedback
└── README.md     — Project summary
```

---

## How Claude Code Assisted Development

This project was built using **Claude Code** as the AI development assistant (replacing Microsoft Copilot) at every stage.

### Activity 1 — Writing and Enhancing CSS

Claude Code generated the complete foundational CSS for Alex Styles' portfolio site:

- **Typography system** — Defined font pairings (Inter + Playfair Display via Google Fonts), fluid `clamp()`-based font sizes that scale across viewport widths, and consistent line-height for readability.
- **Color palette** — Established a cohesive brand palette (deep navy `#1a1a2e`, accent red `#e94560`, off-white `#f8f7f4`) with semantic CSS custom properties, making the entire scheme easy to update.
- **Layout architecture** — Applied CSS Grid for the 3-column portfolio section and Flexbox for the navigation bar and about section, creating a clean, structured foundation.
- **Hover transitions** — Generated smooth `transition` rules on nav links (accent underline reveal), portfolio cards (lift + shadow), and buttons (color shift + vertical translate).
- **Fade-in animations** — Created a `@keyframes fadeInUp` animation applied to each portfolio card with staggered `animation-delay` values for a polished reveal effect on page load.
- **Performance optimization** — Organized CSS in logical sections (reset → custom properties → base → layout → components), eliminated redundant rules, and used `backdrop-filter` and `will-change` only where needed.

### Activity 2 — Responsive Design

Claude Code produced all media queries and responsive layout adaptations:

- **Mobile (max-width: 768px)** — Stacked single-column layout, collapsible hamburger navigation (with smooth `max-height` animation), single-column portfolio grid, full-width contact form, and centered about section.
- **Tablet (max-width: 1024px)** — 2-column portfolio grid, reduced avatar size, and consolidated contact layout.
- **Desktop (min-width: 1025px)** — Full 3-column portfolio grid, side-by-side about layout, and dual-column contact section.
- **Fluid typography** — All font sizes use `clamp()` so they scale naturally between breakpoints without needing extra media query overrides.
- **Flexible form layout** — Contact form adapts from stacked (mobile) to a structured grid layout (desktop) for comfortable data entry on any device.

### Activity 3 — UI/UX Enhancements

Claude Code implemented interactive elements and refined the visual design:

- **Portfolio modal** — Clicking any project card opens a full-screen overlay modal with a blurred backdrop, slide-in animation, project title, and description. Supports close via button, overlay click, or `ESC` key. Fully keyboard-accessible with correct `aria-modal` and `aria-hidden` attributes.
- **Navigation tooltips** — Each nav link uses a `data-tooltip` attribute; CSS `::after` pseudo-elements render styled tooltip bubbles on hover/focus, improving usability without any extra JavaScript.
- **Mobile nav toggle** — JavaScript-powered hamburger menu with `aria-expanded` state management and auto-close on link click.
- **Visual hierarchy refinements** — Added decorative accent underlines to section headings, improved color contrast for body text, and added a focus ring system using `:focus-visible` for accessibility.
- **Button interaction polish** — Buttons lift with `transform: translateY(-2px)` and cast a colored box-shadow on hover, reinforcing interactivity.
- **Form submit feedback** — The contact form provides inline success feedback ("Message Sent!") with automatic reset after 3 seconds, giving users clear confirmation without a page reload.

---

## Features

- Fully responsive (mobile, tablet, desktop)
- Accessible (semantic HTML, ARIA attributes, keyboard navigation, focus management)
- CSS-only tooltips on nav links
- Modal with blur backdrop and slide-in animation for portfolio projects
- Smooth scroll navigation
- CSS `@keyframes` fade-in animation on portfolio cards
- Contact form with HTML5 validation and submit feedback
- No JavaScript frameworks — vanilla HTML, CSS, and JS only

---

## GitHub Pages

Deployed via GitHub Pages from the `main` branch.
Settings → Pages → Source: `main` / `/ (root)`
