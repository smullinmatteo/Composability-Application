function [val, error] = evaluateComposibilityEquations(expr)
    error = 0;
    val = eval(expr);
    if(isnan(val) || isinf(val))
        error = 1;
        val = 0;
    else
        val = eval(expr);
    end
end