// Modern JavaScript for News Website

// Wait for DOM to be ready
document.addEventListener('DOMContentLoaded', function() {
    // Add fade-in animation to cards
    const cards = document.querySelectorAll('.card');
    cards.forEach((card, index) => {
        setTimeout(() => {
            card.classList.add('fade-in');
        }, index * 100);
    });

    // Smooth scrolling for anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });

    // Add loading state to buttons
    document.querySelectorAll('.btn').forEach(btn => {
        btn.addEventListener('click', function() {
            if (this.getAttribute('href') && this.getAttribute('href').startsWith('http')) {
                const originalText = this.innerHTML;
                this.innerHTML = '<span class="loading"></span> טוען...';
                
                setTimeout(() => {
                    this.innerHTML = originalText;
                }, 1000);
            }
        });
    });

    // Auto-refresh notification
    let refreshTimer = 300000; // 5 minutes
    let refreshInterval;

    function startRefreshTimer() {
        refreshInterval = setInterval(() => {
            showRefreshNotification();
        }, refreshTimer);
    }

    function showRefreshNotification() {
        const notification = document.createElement('div');
        notification.className = 'alert alert-info position-fixed';
        notification.style.cssText = `
            top: 20px;
            left: 50%;
            transform: translateX(-50%);
            z-index: 9999;
            border-radius: 25px;
            box-shadow: 0 5px 25px rgba(0,0,0,0.2);
        `;
        notification.innerHTML = `
            <i class="fas fa-sync-alt me-2"></i>
            מעדכן חדשות...
            <button type="button" class="btn-close btn-close-white ms-2" data-bs-dismiss="alert"></button>
        `;
        
        document.body.appendChild(notification);
        
        setTimeout(() => {
            location.reload();
        }, 3000);
    }

    // Start the refresh timer
    startRefreshTimer();

    // Intersection Observer for animations
    if ('IntersectionObserver' in window) {
        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.style.animationDelay = '0s';
                    entry.target.classList.add('fade-in');
                }
            });
        });

        document.querySelectorAll('.news-card').forEach(card => {
            observer.observe(card);
        });
    }

    // Add click tracking (for analytics if needed)
    document.querySelectorAll('a[target="_blank"]').forEach(link => {
        link.addEventListener('click', function() {
            console.log('External link clicked:', this.href);
            // Add analytics tracking here if needed
        });
    });

    // Service Worker registration (for PWA capabilities)
    if ('serviceWorker' in navigator) {
        navigator.serviceWorker.register('/sw.js')
            .then(registration => {
                console.log('SW registered: ', registration);
            })
            .catch(registrationError => {
                console.log('SW registration failed: ', registrationError);
            });
    }
});