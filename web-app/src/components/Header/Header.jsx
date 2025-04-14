import { Link } from 'react-router-dom';
import logo from '../../assets/Images/Icones/Côte à Côte Name.png';
import userIcon from '../../assets/Images/Icones/profil-de-lutilisateur.png';
import dropdownIcon from '../../assets/Images/Icones/fleche-vers-le-bas.png';
import styles from './Header.module.css';

function Header() {
  return (
    <header className={styles.header}>
      <div className={styles.logo}>
        <img src={logo} alt="Logo Côte à Côte" />
      </div>
      <nav className={styles.nav}>
        <ul className={styles.navLinks}>
          <li><Link to="/Homepage">Accueil</Link></li>
          <li><Link to="/Searchpage">Recherche</Link></li>
          <li><Link to="/Publishpage">Publier</Link></li>
          <li><Link to="/Journeyspage">Mes trajets</Link></li>
          <li><Link to="/Communitypage">Communauté</Link></li>
          <li><Link to="/Helppage">Aidez-moi</Link></li>
        </ul>
        <div className={styles.userActions}>
          <div className={styles.userProfile}>
            <div className={styles.userMenu}>
            <Link to="/Profilepage"><img src={userIcon} alt="User" className={styles.userIcon}/></Link> 
              <img src={dropdownIcon} alt="Menu" className={styles.dropdownIcon} />
            </div>
            <div className={styles.authButtons}>
              <button className={`${styles.btn} ${styles.btnOutline}`}>Sign in</button>
              <button className={`${styles.btn} ${styles.btnPrimary}`}>Register</button>
            </div>
          </div>
        </div>
      </nav>
    </header>
  );
}

export default Header;
