function startMonitor() {
    // Get the target node
    const targetNode = document.getElementById('dynamic');

    // Get the element that we'll output the logs to
    const monitorLog = document.getElementById('monitorLog');

    // Options for the observer (which mutations to observe)
    const config = { attributes: true, childList: true, subtree: true, characterData: true };

    // Callback function to execute when mutations are observed
    const callback = function (mutationsList, observer) {
        const timestamp = new Date().toLocaleString();

        for (let mutation of mutationsList) {
            let textNode = document.createTextNode(`${timestamp} Mutation type: ${mutation.type}`);

            if (mutation.type === 'childList') {
                for (let addedNode of mutation.addedNodes) {
                    textNode.textContent += '\nAdded Node id: ' + addedNode.id;
                    textNode.textContent += '\nAdded Node HTML: ' + addedNode.outerHTML;
                }

                for (let removedNode of mutation.removedNodes) {
                    textNode.textContent += '\nRemoved Node id: ' + removedNode.id;
                    textNode.textContent += '\nRemoved Node HTML: ' + removedNode.outerHTML;
                }

            } else if (mutation.type === 'attributes') {
                textNode.textContent += ', attribute changed: ' + mutation.attributeName;
                textNode.textContent += ', new value: ' + mutation.target.getAttribute(mutation.attributeName);
            } else if (mutation.type === 'characterData') {
                textNode.textContent += ', content changed: ' + mutation.target.data;
            }

            textNode.textContent += '\n\n';
            monitorLog.appendChild(textNode);
        }
    };

    // Create an observer instance linked to the callback function
    const observer = new MutationObserver(callback);

    // Start observing the target node for configured mutations
    observer.observe(targetNode, config);
}

function clearLog() {
    const monitorLog = document.getElementById('monitorLog');
    monitorLog.textContent = '';
}




let nextType = 0;
const height = 6;
let grid = new Array(height).fill(null);

function add() {
    if (grid[0] !== null) {
        grid = new Array(height).fill(null);
    }

    let lastEmptyRow = 0;
    for (let i = 1; i < height; i++) {
        if (grid[i] === null) {
            lastEmptyRow = i;
        } else {
            break;
        }
    }

    grid[lastEmptyRow] = nextType;

    nextType = (nextType + 1) % 2;

    render();
}

function render() {
    const container = document.getElementById('container');
    let children = container.children;

    // First pos where grid is not null
    let row = 0;
    for (let i = 0; i < grid.length; i++) {
        if (grid[i] !== null) {
            row = i;
            break;
        }
    }

    if (children.length > (grid.length - row)) {
        container.innerHTML = '';
    }


    // Iterate existing children
    for (let i = 0; i < children.length; i++) {
        const div = children[i];

        div.id = 'row' + row;
        div.className = 'box type' + grid[row] + ' row' + row;

        const img = div.children[0];
        img.id = 'row-image' + row;
        img.src = '_content/RazorClassLibrary1/marble-' + (grid[row] + 1) + '.svg';

        row++;
    }

    // Add new children
    for (let i = row; i < grid.length; i++) {
        const div = document.createElement('div');
        div.id = 'row' + row;
        div.className = 'box type' + grid[row] + ' row' + row;

        const img = document.createElement('img');
        img.id = 'row-image' + row;
        img.className = 'marble';
        img.src = '_content/RazorClassLibrary1/marble-' + (grid[row] + 1) + '.svg';

        container.appendChild(div);
        div.appendChild(img);
    }
}

function startJavaScriptMode() {
    document.getElementById('add-button').addEventListener('click', add);
    window.addEventListener('DOMContentLoaded', (event) => {
        render();
    });
}


