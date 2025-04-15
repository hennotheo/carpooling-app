import styles from './Publish.module.css';

function Publish() {
  return (
    <main className={styles.centerpage}>
      <section className={styles.filters}>
        <div className={styles.filterBlock}>
          <label htmlFor="vehicle-select">Sélection du véhicule</label>
          <select id="vehicle-select">
            <option value="default">Sélectionner</option>
            <option value="electric">Renault Kangoo</option>
            <option value="verified">Fiat Multipla</option>
            <option value="luxury">Yogo</option>
          </select>
        </div>

        <h3>Option de trajet</h3>
        <div className={styles.filterBlock}>
          <ul>
            <li><input type="checkbox" defaultChecked /> Animaux autorisés</li>
            <li><input type="checkbox" /> Trajet en musique</li>
            <li><input type="checkbox" defaultChecked /> Max 2 à l'arrière</li>
            <li><input type="checkbox" /> Prise électrique</li>
            <li><input type="checkbox" defaultChecked /> Siège inclinable</li>
            <li><input type="checkbox" defaultChecked /> Climatisation</li>
            <li><input type="checkbox" /> Cigarette autorisée</li>
          </ul>
        </div>
      </section>

      <button className={styles.publishBtn}>Publier</button>
    </main>
  );
}

export default Publish;