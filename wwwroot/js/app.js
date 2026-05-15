/* JuniorPower — app.js */

document.addEventListener('DOMContentLoaded', () => {
    initSidebar();
    loadGlobalProgress();
    initCollapseChevrons();
    addAntiForgeryToFetch();
});

// ===== SIDEBAR =====
function initSidebar() {
    const toggle = document.getElementById('sidebarToggle');
    const sidebar = document.getElementById('sidebar');
    if (!toggle || !sidebar) return;

    toggle.addEventListener('click', () => {
        sidebar.classList.toggle('open');
    });

    document.addEventListener('click', (e) => {
        if (window.innerWidth <= 768 &&
            !sidebar.contains(e.target) &&
            !toggle.contains(e.target)) {
            sidebar.classList.remove('open');
        }
    });
}

// ===== GLOBAL PROGRESS IN SIDEBAR =====
async function loadGlobalProgress() {
    try {
        const res = await fetch('/Progress/Stats');
        if (!res.ok) return;
        const data = await res.json();

        const pct = data.total > 0 ? Math.round(data.completed / data.total * 100) : 0;

        const bar = document.getElementById('sidebar-bar');
        const label = document.getElementById('sidebar-percent');

        if (bar) bar.style.width = pct + '%';
        if (label) label.textContent = pct + '%';
    } catch (_) {}
}

// ===== COLLAPSE CHEVRONS =====
function initCollapseChevrons() {
    document.querySelectorAll('[data-bs-toggle="collapse"]').forEach(trigger => {
        const targetId = trigger.getAttribute('data-bs-target');
        const target = document.querySelector(targetId);
        if (!target) return;

        const chevron = trigger.querySelector('.timeline-chevron');

        target.addEventListener('show.bs.collapse', () => {
            if (chevron) chevron.style.transform = 'rotate(180deg)';
        });

        target.addEventListener('hide.bs.collapse', () => {
            if (chevron) chevron.style.transform = 'rotate(0deg)';
        });

        // Collapse all except day 1 by default on study plan page
        if (!target.classList.contains('show')) {
            if (chevron) chevron.style.transform = 'rotate(0deg)';
        }
    });
}

// ===== ANTI-FORGERY for POST =====
function addAntiForgeryToFetch() {
    const originalFetch = window.fetch;
    window.fetch = async (url, options = {}) => {
        if (options.method === 'POST' && !options.body) {
            options.headers = options.headers || {};
        }
        return originalFetch(url, options);
    };
}

// ===== TASK TOGGLE (global, reused in multiple pages) =====
async function toggleTask(taskId) {
    try {
        const res = await fetch('/Tasks/Toggle/' + taskId, { method: 'POST' });
        if (!res.ok) return;
        const data = await res.json();

        const item = document.getElementById('task-' + taskId);
        if (!item) return;

        const icon = item.querySelector('.task-toggle i');

        if (data.isCompleted) {
            item.classList.add('task-item--done');
            if (icon) icon.className = 'bi bi-check-circle-fill text-success';
        } else {
            item.classList.remove('task-item--done');
            if (icon) icon.className = 'bi bi-circle';
        }

        updateLocalProgress(item);
        loadGlobalProgress();

    } catch (e) {
        console.error('Error toggling task:', e);
    }
}

function updateLocalProgress(taskItem) {
    const card = taskItem.closest('.card-dark');
    if (!card) return;

    const items = card.querySelectorAll('.task-item');
    const done = card.querySelectorAll('.task-item--done').length;
    const total = items.length;
    const pct = total > 0 ? Math.round(done / total * 100) : 0;

    const bar = card.querySelector('.progress-bar');
    if (bar) bar.style.width = pct + '%';

    const label = card.querySelector('small.text-muted');
    const countLabels = card.querySelectorAll('small.text-muted');
    countLabels.forEach(el => {
        if (/^\d+ \/ \d+$/.test(el.textContent.trim())) {
            el.textContent = done + ' / ' + total;
        }
    });
}
