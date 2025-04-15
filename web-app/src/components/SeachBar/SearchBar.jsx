import React from 'react';
import styles from './SearchBar.module.css'; // Import du CSS Module

function SearchBar() {
  return (
    <section className={styles.searchBar}>
      <div className={styles.searchItem}>
        <i className="fas fa-map-marker-alt"></i>
        <input type="text" placeholder="Lieu de départ" />
      </div>
      <div className={styles.searchItem}>
        <i className="fas fa-map-marker-alt"></i>
        <input type="text" placeholder="Lieu d’arrivée" />
      </div>
      <div className={styles.searchItem}>
        <i className="fas fa-calendar-alt"></i>
        <input type="date" />
      </div>
      <button className={styles.searchBtn}>
        <i className="fas fa-search"></i>
      </button>
    </section>
  );
}

export default SearchBar;
  