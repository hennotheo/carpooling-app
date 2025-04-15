import styles from './Journey.module.css';
import ResultCard from '../ResultCard/ResultCard.jsx';

function Journey() {
  // Exemple temporaire : simulate database fetch
  const results = Array.from({ length: 12 }, (_, i) => ({
    id: i,
    date: '2023-07-12',
    name: i === 1 ? 'Gerard B. 45 ans' : 'Coucou',
    description: 'A dialog is a type of modal window...',
    from: 'Lille',
    to: 'Bordeaux',
    price: '0.00',
  }));

  return (
    <div className={styles.centerpage}>
      <section className={styles.results}>
        {results.map((result) => (
          <ResultCard key={result.id} {...result} />
        ))}
      </section>
    </div>
  );
}

export default Journey;
