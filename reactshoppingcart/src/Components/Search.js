import React, {useState} from 'react'; //useState is a hook DI

export default function Search({data}) {
    return(
        <div className='searchBar'>
            <div className='searchInput'> 
                <input type="text" placeholder='Search for anything...'/>
            </div>
        </div>
    )
}