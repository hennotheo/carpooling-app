import styles from './HomePage.module.css';

function HomePage() {
  return (
    <>
      {/* Main Content */}
      <div className={styles.mainContent}>
        {/* Map Section */}
        <section className={styles.map}>
          <iframe
            title="Carte Amiens"
            src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d99266.27373366256!2d2.2022813502071727!3d49.89879178350202!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x47e78413d78b760b%3A0x40af13e816220e0!2sAmiens!5e1!3m2!1sfr!2sfr!4v1743685979257!5m2!1sfr!2sfr"
            className={styles.mapFrance}
            allowFullScreen=""
            loading="lazy"
            referrerPolicy="no-referrer-when-downgrade"
          ></iframe>
        </section>

        {/* Profiles Section */}
        <section className={styles.profilesSection}>
          <div className={styles.profilesContainer}>
            <div className={styles.testimonialGrid}>
              <div className={styles.testimonialCard}>
                <h3>Gerard B. 45 ans</h3>
                <p>
                  A dialog is a type of modal window that appears in front of app
                  content to provide critical information, or prompt for a decision
                  to be made.
                </p>
              </div>
              <div className={styles.testimonialCard}>
                <h3>Nadege P. 32 ans</h3>
                <p>Same text here.</p>
              </div>
              <div className={styles.testimonialCard}>
                <h3>Pessi P. 38 ans</h3>
                <p>Same text here.</p>
              </div>
              <div className={styles.testimonialCard}>
                <h3>Titouan F. 18 ans</h3>
                <p>Same text here.</p>
              </div>
            </div>
            <div className={styles.profilesScrollbar}>
              <div className={styles.scrollbarThumb}></div>
            </div>
          </div>
        </section>
      </div>

      {/* Reviews Section */}
      <section className={styles.reviews}>
        <h2>Les commandes Biens Cuites</h2>
        <div className={styles.reviewsGrid}>
          <div className={styles.reviewCard}>
            <div className={styles.stars}>
              {[...Array(5)].map((_, i) => (
                <img
                  key={i}
                  src="../Images/Icones/etoile.png"
                  alt="Star"
                  className={styles.star}
                />
              ))}
            </div>
            <h3>Review title</h3>
            <p>Review body</p>
            <div className={styles.reviewer}>
              <div className={styles.reviewerAvatar}></div>
              <div className={styles.reviewerInfo}>
                <div className={styles.reviewerName}>Reviewer name</div>
                <div className={styles.reviewerDate}>Date</div>
              </div>
            </div>
          </div>

          {[2, 3].map((n) => (
            <div key={n} className={styles.reviewCard}>
              <div className={styles.stars}>
                {[...Array(5)].map((_, i) => (
                  <img
                    key={i}
                    src="../Images/Icones/etoile.png"
                    alt="Star"
                    className={styles.star}
                  />
                ))}
              </div>
              <h3>Review title {n}</h3>
              <p>Review body</p>
              <div className={styles.reviewer}>
                <div className={styles.reviewerAvatar}></div>
                <div className={styles.reviewerInfo}>
                  <div className={styles.reviewerName}>Reviewer name</div>
                  <div className={styles.reviewerDate}>Date</div>
                </div>
              </div>
            </div>
          ))}
        </div>
      </section>

      {/* Gallery Section */}
      <section className={styles.gallery}>
        <img
          src="https://www.radiofrance.fr/s3/cruiser-production-eu3/2023/06/a9914c48-e496-40ea-ab45-003b652d5294/640x340_sc_sc-gettyimages-548140927.jpg"
          alt="1 photo ou deux"
        />
        <img
          src="https://www.lamarseillaise.fr/binrepository/400x296/1c59/400d225/none/150910102/CPTW/photo-4_542-6033008_20220924072456.jpg"
          alt="1 photo ou deux"
        />
      </section>
    </>
  );
}

export default HomePage;
