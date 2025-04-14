import styles from './Community.module.css';

function Community() {
  return (
    <div className={styles.centerpage}>
      {/* 🔧 Bannière de maintenance */}
      <div className={styles.maintenanceBanner}>
        <p>🚧 Côte À Côte Communauté est en maintenance, mais notre forum est donc inaccessible.</p>
        <a href="/" className={styles.btnRetour}>Retour à l'accueil</a>
      </div>

      {/* 🧾 Forum */}
      <section className={styles.forumWrapper}>
        <h1 className={styles.forumTitle}>Forum de la Communauté</h1>

        <div className={styles.forumThread}>
          <h3>🚗 Question : Quel véhicule vintage recommandez-vous pour un long trajet ?</h3>
          <p><strong>Posté par : JeanMi67</strong> – “Je prévois un trajet Strasbourg → Marseille cet été, et j’aimerais faire ça en style. Des suggestions de voitures fiables ?”</p>
        </div>

        <div className={styles.forumThread}>
          <h3>🎶 Musique sur la route : vos playlists ?</h3>
          <p><strong>Posté par : Clém</strong> – “Quels morceaux vous écoutez pendant un trajet Côte à Côte ?”</p>
        </div>

        <div className={styles.forumThread}>
          <h3>🛠️ Entretien avant départ</h3>
          <p><strong>Posté par : Romain13</strong> – “Vous vérifiez quoi avant de partir ? Pneus, freins, huile ?”</p>
        </div>

        {/* Formulaire */}
        <section className={styles.contactForm}>
          <h2>Publier un nouveau message</h2>
          <form action="#" method="post">
            <label htmlFor="name">Nom :</label>
            <input type="text" id="name" name="name" required />

            <label htmlFor="email">Email :</label>
            <input type="email" id="email" name="email" required />

            <label htmlFor="message">Message :</label>
            <textarea id="message" name="message" rows="6" required></textarea>

            <button type="submit">Envoyer</button>
          </form>
        </section>
      </section>
    </div>
  );
}

export default Community;
