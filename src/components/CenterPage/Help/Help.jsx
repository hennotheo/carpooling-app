import styles from './Help.module.css';

function Help() {
  return (
    <div className={styles.centerpage}>
      <section className={styles.helpSection}>
        <section className={styles.auSection}>
          <h1>Comment ça marche ?</h1>
          <p>Bienvenue sur Côte à Côte, la plateforme de covoiturage qui vous permet de partager vos trajets en toute simplicité.</p>

          <h2>Comment publier un trajet ?</h2>
          <p>Pour publier un trajet, connectez-vous à votre compte et cliquez sur le bouton "Publier". Remplissez les informations demandées, telles que la date, l'heure et le lieu de départ et d'arrivée. Une fois que vous avez soumis votre trajet, il sera visible par les autres utilisateurs.</p>

          <h2>Comment rechercher un trajet ?</h2>
          <p>Pour rechercher un trajet, allez dans la section "Rechercher" et entrez vos critères de recherche. Vous pouvez filtrer par date, heure et lieu. Une fois que vous avez trouvé un trajet qui vous convient, vous pouvez contacter le conducteur pour organiser les détails.</p>

          <h2>Comment contacter un conducteur ?</h2>
          <p>Pour contacter un conducteur, allez dans la section "Mes trajets" et trouvez le trajet qui vous intéresse. Cliquez sur le bouton "Contacter" pour envoyer un message au conducteur. Vous pouvez discuter des détails du trajet et convenir d'un point de rendez-vous.</p>

          <h2>Comment gérer mes trajets ?</h2>
          <p>Pour gérer vos trajets, allez dans la section "Mes trajets". Vous pouvez voir tous vos trajets publiés et réservés. Vous pouvez également modifier ou supprimer un trajet si nécessaire.</p>

          <h2>Comment supprimer mon compte ?</h2>
          <p>Pour supprimer votre compte, allez dans les paramètres de votre profil et cliquez sur "Supprimer mon compte". Veuillez noter que cette action est irréversible et que toutes vos données seront supprimées.</p>

          <h2>Comment contacter le support ?</h2>
          <p>Pour contacter le support, remplissez le formulaire de contact ci-dessous. Nous nous efforcerons de répondre à votre demande dans les plus brefs délais.</p>
        </section>

        <section className={styles.contactForm}>
          <h1>Formulaire de contact</h1>
          <form action="#" method="post">
            <label htmlFor="name">Nom :</label>
            <input type="text" id="name" name="name" required />

            <label htmlFor="email">Email :</label>
            <input type="email" id="email" name="email" required />

            <label htmlFor="message">Message :</label>
            <textarea id="message" name="message" rows="10" required></textarea>

            <button type="submit">Envoyer</button>
          </form>
        </section>
      </section>
    </div>
  );
}

export default Help;
