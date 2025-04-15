import React from 'react';
import chatBulle from '../../../assets/Images/Icones/chat-a-bulles.png'; // Import de l'icône de chat
import banner from '../../../assets/Images/Icones/Banniere.jpg'; // Import de l'image de couverture
import styles from './Profile.module.css'; // Import du CSS Module

function Profile() {
  return (
    <main>
      {/* En-tête du profil */}
      <div className={styles.profileHeader}>
        <div className={styles.profileCover}>
          <img 
            src={banner}
            alt="Cover photo" 
            className={styles.coverPhoto} 
          />
          <div className={styles.profileInfo}>
            <img 
              src="../Images/Icones/bebert.jpg" 
              alt="Large profile picture" 
              className={styles.largeProfilePic} 
            />
            <div className={styles.profileText}>
              <h1>Albert Einstein</h1>
              <p>Membre depuis 2023</p>
            </div>
          </div>
        </div>
      </div>

      {/* Contenu principal du profil */}
      <div className={styles.profileContent}>
        {/* Sidebar */}
        <div className={styles.profileSidebar}>
          <div className={styles.profileStats}>
            <div className={styles.statItem}>
              <span className={styles.statNumber}>42</span>
              <span className={styles.statLabel}>Trajets</span>
            </div>
            <div className={styles.statItem}>
              <span className={styles.statNumber}>4.8</span>
              <span className={styles.statLabel}>Note</span>
            </div>
            <div className={styles.statItem}>
              <span className={styles.statNumber}>156</span>
              <span className={styles.statLabel}>Avis</span>
            </div>
          </div>
          
          <div className={styles.profileActions}>
            <button className={styles.btnPrimary}>Modifier le profil</button>
            <button className={styles.btnSecondary}>Paramètres</button>
          </div>

          <div className={styles.profilePreferences}>
            <div className={styles.preferenceItem}>
              <img 
                src={chatBulle} 
                alt="blabla" 
                className={styles.iconPreference} 
              />
              <span>J'aime bien discuter quand je me sens à l'aise</span>
            </div>
            <div className={styles.preferenceItem}>
              <img 
                src="../Images/Icones/lecteur-de-musique.png" 
                alt="blabla" 
                className={styles.iconPreference} 
              />
              <span>Musique tout le long !</span>
            </div>
            <div className={styles.preferenceItem}>
              <img 
                src="../Images/Icones/fumeur.png" 
                alt="blabla" 
                className={styles.iconPreference} 
              />
              <span>Voyager avec des fumeurs ne me dérange pas</span>
            </div>
            <div className={styles.preferenceItem}>
              <img 
                src="../Images/Icones/pattes.png" 
                alt="blabla" 
                className={styles.iconPreference} 
              />
              <span>Je peux voyager avec certains animaux</span>
            </div>
          </div>
        </div>

        {/* Contenu principal */}
        <div className={styles.profileMain}>
          {/* Section À propos */}
          <section className={styles.aboutSection}>
            <h2>À propos</h2>
            <p>Passionné de voyages et d'expériences en tous genres.</p>
          </section>

          {/* Section des avis */}
          <section className={styles.reviewsSection}>
            <h2>Avis reçus</h2>
            <div className={styles.reviewCards}>
              <div className={styles.reviewCard}>
                <div className={styles.reviewHeader}>
                  <img 
                    src="../Images/Icones/Marilyn.jpg" 
                    alt="Reviewer" 
                    className={styles.reviewerPic} 
                  />
                  <div className={styles.reviewerInfo}>
                    <h3>Marilyn M.</h3>
                    <div className={styles.stars}>★★★★★</div>
                  </div>
                </div>
                <p className={styles.reviewText}>
                  Excellent conducteur, très ponctuel et sympathique !
                </p>
                <span className={styles.reviewDate}>12 janvier 2024</span>
              </div>

              <div className={styles.reviewCard}>
                <div className={styles.reviewHeader}>
                  <img 
                    src="../Images/Icones/oppenh.jpg" 
                    alt="Reviewer" 
                    className={styles.reviewerPic} 
                  />
                  <div className={styles.reviewerInfo}>
                    <h3>Robbert O.</h3>
                    <div className={styles.stars}>★★★★★</div>
                  </div>
                </div>
                <p className={styles.reviewText}>Trajet très agréable, discussion intéressante.</p>
                <span className={styles.reviewDate}>5 janvier 2024</span>
              </div>
            </div>
          </section>
        </div>
      </div>
    </main>
  );
}

export default Profile;
