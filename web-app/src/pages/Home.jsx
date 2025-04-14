import Header from '../components/Header/Header';
import SearchBar from '../components/SeachBar/SearchBar';
import CenterPage from '../components/CenterPage/CenterPage';
import Footer from '../components/Footer/Footer';
import App from './App.jsx';

function Home() {
  return (
    <div className="page-wrapper">
      <Header />
      <SearchBar />
      <CenterPage />
      <Footer />
    </div>
  );
}

export default Home;
