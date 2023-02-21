<p class="notice">Under this notice, you can see the filter component. - in /filter.php </p>
<div class="roundedcornes shadow filter" id="filtermenu">
    <h2 class="filterh2">Filter menu</h2>
    <input type="text" class="search-input lg" value placeholder="Type here the name of the game ... e.g. Apple">
    <input type="text" class="search-input sm" value placeholder="Search">
    <hr>
    <h2 class="filterh2">Filters</h2>
    <div class="ch-labels">
    <label class="ch-label">Click-To-Play (.js WEB)
        <input type="checkbox" checked="checked">
        <span class="checkmark"></span>
    </label>
    <label class="ch-label">Downloadable (.exe GUI)
        <input type="checkbox" checked="checked">
        <span class="checkmark"></span>
    </label>
    <label class="ch-label">Python files (.py CLI)
        <input type="checkbox" checked="checked">
        <span class="checkmark"></span>
    </label>
    </div>  
    <label for='styledSelect1' class='dd-filter'>
        <select id="styledSelect1" name='options'>
            <option value=''>Creator Name</option>
            <option value='1'>gydoma</option>
            <option value='2'>lorem placeholer 2</option>
            <option value='3'>ph 3</option>
            <option value='4'>placeholder 4</option>
        </select>
    </label>
    <div id="ratingfilter">
    <h2>Minimum Rating: <!-- 0.1 - 5.0 star rating --> </h2>
    <input type="range" min="1" max="50" value="25" class="min-star" id="min-star">
</div>
<input type="submit" id="searchbtn" value="Click To Search">
</div>
<p class="notice">Above this notice, you can see the filter component. - in /filter.php </p>
