import styles from './ResultCard.module.css';
import Fleche from '../../../assets/Images/Icones/Fleche.png';

function ResultCard({ date, name, description, from, to, price }) {
  return (
    <div className={styles.resultCard}>
      <p>Date: {date}</p>
      <h4>{name}</h4>
      <p>{description}</p>
      <div className={styles.route}>
        <span>{from}</span>
        <img src={Fleche} alt="Arrow" />
        <span>{to}</span>
        <span className={styles.price}>{price}€</span>
      </div>
    </div>
  );
}

export default ResultCard;
