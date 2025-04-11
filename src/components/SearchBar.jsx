function SearchBar() {
    return (
      <section className="search-bar">
        <div className="search-item">
          <i className="fas fa-map-marker-alt"></i>
          <input type="text" placeholder="Lieu de départ" />
        </div>
        <div className="search-item">
          <i className="fas fa-map-marker-alt"></i>
          <input type="text" placeholder="Lieu d’arrivée" />
        </div>
        <div className="search-item">
          <i className="fas fa-calendar-alt"></i>
          <input type="date" />
        </div>
        <button className="search-btn">
          <i className="fas fa-search"></i>
        </button>
      </section>
    );
  }
  
  export default SearchBar;
  