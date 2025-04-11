import fb from "../assets/Images/Icones/facebook.png";
import linkedin from "../assets/Images/Icones/linkedin.png";
import youtube from "../assets/Images/Icones/youtube.png";
import instagram from "../assets/Images/Icones/instagram.png";

function Footer() {
    return (
      <footer class="footer">
      <div class="footer-content">
        <div class="footer-brand">
          <h2>CoteACote.fr</h2>
          <div class="social-icons">
              <a href="#"><img src={fb} alt="Facebook"/></a>
              <a href="#"><img src={linkedin} alt="LinkedIn"/></a>
              <a href="#"><img src={youtube} alt="YouTube"/></a>
              <a href="#"><img src={instagram} alt="Instagram"/></a>
          </div>
        </div>
        <div class="footer-links">
          <div class="footer-column">
              <h4>À propos</h4>
              <a href="#">Qui sommes-nous</a>
              <a href="#">Contact</a>
              <a href="#">Carrières</a>
          </div>
          <div class="footer-column">
              <h4>Aide</h4>
              <a href="#">Centre d'aide</a>
              <a href="#">FAQ</a>
              <a href="#">Support</a>
          </div>
          <div class="footer-column">
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
  