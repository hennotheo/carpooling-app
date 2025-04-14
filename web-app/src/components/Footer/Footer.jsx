import styles from './Footer.module.css';
import fb from "../../assets/Images/Icones/facebook.png";
import linkedin from "../../assets/Images/Icones/linkedin.png";
import youtube from "../../assets/Images/Icones/youtube.png";
import instagram from "../../assets/Images/Icones/instagram.png";

function Footer() {
  return (
    <footer className={styles.footer}>
      <div className={styles.footerContent}>
        <div className={styles.footerBrand}>
          <h2>CoteACote.fr</h2>
          <div className={styles.socialIcons}>
            <a href="#"><img src={fb} alt="Facebook" /></a>
            <a href="#"><img src={linkedin} alt="LinkedIn" /></a>
            <a href="#"><img src={youtube} alt="YouTube" /></a>
            <a href="#"><img src={instagram} alt="Instagram" /></a>
          </div>
        </div>

        <div className={styles.footerLinks}>
          <div className={styles.footerColumn}>
            <h4>À propos</h4>
            <a href="#">Qui sommes-nous</a>
            <a href="#">Contact</a>
            <a href="#">Carrières</a>
          </div>
          <div className={styles.footerColumn}>
            <h4>Aide</h4>
            <a href="#">Centre d'aide</a>
            <a href="#">FAQ</a>
            <a href="#">Support</a>
          </div>
          <div className={styles.footerColumn}>
            <h4>Légal</h4>
            <a href="#">Conditions</a>
            <a href="#">Confidentialité</a>
            <a href="#">Cookies</a>
          </div>
        </div>
      </div>
    </footer>
  );
}

export default Footer;

  