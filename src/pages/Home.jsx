import Header from '../components/Header';
import SearchBar from '../components/SearchBar';
import CenterPageJourney from '../components/CenterPageJourney';
import Footer from '../components/Footer';

function Home() {
  return (
    <div className="page-wrapper">
      <Header />
      <SearchBar />
      <CenterPageJourney />
      <Footer />
    </div>
  );
}

export default Home;