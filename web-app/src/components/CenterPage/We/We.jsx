import React from 'react';
import styles from './We.module.css'; // Import du CSS Module

function We() {
  return (
    <div className={styles.centerpage}>
      {/* Logo M2I Formation */}
      <img 
        src="../Images/Icones/logo_m2iformation.webp" 
        alt="Logo M2I Formation" 
        className={styles.logoM2I}
      />

      {/* Liste des créateurs */}
      <ul className={styles.listCreateur}>
        <li className={styles.nomCreateur}>
          Théo HENNO : <span className={styles.nom}>Développeur Back-End</span>
        </li>
        <li className={styles.nomCreateur}>
          Alexandre MAHBOUB : <span className={styles.nom}>Développeur Front-End</span>
        </li>
        <li className={styles.nomCreateur}>
          Mattéo GEST : <span className={styles.nom}>UI/UX Designer / Développeur Front-End</span>
        </li>
      </ul>
    </div>
  );
}

export default We;