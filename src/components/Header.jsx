import logo from '../assets/Images/Icones/Côte à Côte Name.png';
import imgProf from '../assets/Images/Icones/profil-de-lutilisateur.png';

function Header() {
    return (
      <header>
        <div className="logo">
          <img src={logo} alt="Logo Côte à Côte" />
        </div>
        <nav>
          <ul className="nav-links">
            <li><a href="/Publishpage">Publier</a></li>
            <li><a href="/Journeyspage">Mes trajets</a></li>
            <li><a href="/Communitypage">Communauté</a></li>
            <li><a href="/Helppage">Aidez-moi</a></li>
          </ul>
          <div className="profile">
            <img src={imgProf} className="imgProf" alt="Profil" />
            <div className="auth-buttons">
              <button className="sign-in">Sign in</button>
              <button className="register">Register</button>
            </div>
          </div>
        </nav>
      </header>
    );
  }
  
  export default Header;